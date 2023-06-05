using SugarShark.Application.Common;
using SugarShark.Application.OrderModule.Repositories;
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

        public OrderRepository(ISugarSharkDbContext dbContext) :base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public int PlaceOrder(Order order)
        {

            _dbContext.Orders.Add(order);

            return Commit();
        }
    }
}
