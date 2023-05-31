using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.Common;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.OrderModule.Repertories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private ISugarSharkDbContext _dbContext;

        public OrderRepository(ISugarSharkDbContext dbContext) :base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public int PlaceOrder(Order order)
        {
            var cartExit=_dbContext.Carts.Any(x=>x.Id == order.CartId);

            if (!cartExit)
                throw new InvalidOperationException("Votre panier est vide");

            _dbContext.Orders.Add(order);
            return 1;
        }
    }
}
