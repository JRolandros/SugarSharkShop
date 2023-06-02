using Microsoft.EntityFrameworkCore;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Domain.Common;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.CartModule.Repertories
{
    public class CartRepository : BaseRepository, ICartRepository
    {

        public CartRepository(SugarSharkDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<CartItemProxy> GetCartItemsWithProducts(int cartId)
        {
            var all = from item in _dbContext.CartItems
                      join product in _dbContext.Products on item.ProductId equals product.Id
                      where item.CartId == cartId
                      select new CartItemProxy { CartItem = item, Product = product };

            return all;
        }

        public IEnumerable<CartItem> GetCartItemsByCartId(int cartId)
        {
            var items=_dbContext.CartItems.Where(x => x.CartId == cartId);
            return items;
        }
        public CartItem GetCartItemById(int id)
        {
            var item = _dbContext.CartItems.FirstOrDefault(x => x.Id == id);

            return item;
        }

        public CartItem GetCartItemByProductIdCartId(int productId, int cartId)
        {
            var item = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            return item;
        }
        public int AddCartItem(CartItem item)
        {
            if (!_dbContext.Carts.Any(x => x.Id == item.CartId))
                throw new Exception("Violation de la constrainte de clé étranger");

            _dbContext.CartItems.Add(item);

            int ok = Commit();

            return ok;
        }

        public int DeleteCartItem(int productId, int cartId)
        {
            var itemToDelete = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            if (itemToDelete == null)
                throw new InvalidOperationException("Ce produit n'existe pas");

            _dbContext.CartItems.Remove(itemToDelete);

            int ok = Commit();

            return ok;
        }

        private Cart getCart(int userId)
        {
            var cart = _dbContext
                        .Carts
                        .FirstOrDefault(c => c.UserId == userId);

            return cart;
        }

        private Cart getCartWithItems(int userId)
        {
            var cart = _dbContext
                        .Carts
                        .Include(x=>x.CartItems)
                        .FirstOrDefault(c => c.UserId == userId);

            return cart;
        }

        public Cart GetCart(int userId,bool includeItems=false)
        {
            try
            {
                var cart =includeItems? getCartWithItems(userId) : getCart(userId);

                if (cart == null)
                {
                    cart = new Cart() { UserId = userId, ValidityEndDate = DateTime.Now };

                    CreateCartIfNotExit(cart);

                    cart = includeItems ? getCartWithItems(userId) : getCart(userId);
                }

                return cart;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int DeleteCart(int userId)
        {
            var cart = getCart(userId);

            _dbContext.Carts.Remove(cart);

            return Commit();
        }
        public int UpdateCartItem(CartItem item)
        {
            _dbContext.CartItems.Update(item);

            return Commit();
        }

        public int UpdateCartItemQty(int productId, int cartId, int quantity)
        {
            var toUpdate = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            if (toUpdate == null)
                return 0;
            toUpdate.Quantity = quantity;

            _dbContext.CartItems.Update(toUpdate);

            Commit();

            return 1;
        }

        public int CreateCartIfNotExit(Cart cart)
        {
            var exist = _dbContext.Carts.FirstOrDefault(x => x.Id == cart.Id);

            if (exist == null)
            {
                var d = _dbContext.Carts.Add(cart);

                exist = cart;

                Commit();
            }

            return exist.Id;
        }
    }
}
