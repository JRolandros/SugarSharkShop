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
            throw new NotImplementedException();
        }

        public int DeleteCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(int userId)
        {
            var cart = _dbContext
                .Carts
                .Include(c => c.CartItems)
                .First(c => c.UserId == userId);

            return cart;
        }

        public int UpdateCartItemQty(int id, int v)
        {
            throw new NotImplementedException();
        }
    }
}
