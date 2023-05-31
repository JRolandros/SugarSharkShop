using Microsoft.EntityFrameworkCore;
using SugarShark.Application.CatalogModule.Repositories;
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

        public CartRepository(SugarSharkDbContext dbContext) :base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public int AddCartItem(CartItem item)
        {
            if (!_dbContext.Carts.Any(x => x.Id == item.CartId))
                throw new Exception("Violation de la constrainte de clé étranger");

            _dbContext.CartItems.Add(item);

            int ok=Commit();

            return ok;
        }

        public int DeleteCartItem(int id)
        {
            var itemToDelete=_dbContext.CartItems.FirstOrDefault(x=> x.Id == id);
            if (itemToDelete == null)
                throw new InvalidOperationException("Ce produit n'existe pas");

            _dbContext.CartItems.Remove(itemToDelete);

            int ok=Commit();

            return ok;
        }

        public Cart GetCart(int userId)
        {
            try
            {
                var cart = _dbContext
                        .Carts
                        .Include(c => c.CartItems)
                        .First(c => c.UserId == userId);

                return cart;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Le panier est vide",ex);
            }

            
        }

        public int UpdateCartItemQty(int id, int v)
        {
            throw new NotImplementedException();
        }

        public int CreateCartIfNotExit(Cart cart)
        {
            var exist= _dbContext.Carts.FirstOrDefault(x => x.Id == cart.Id);

            if (exist == null)
            {
                var d=_dbContext.Carts.Add(cart);

                exist = cart;

                Commit();
            }

            return exist.Id;
        }
    }
}
