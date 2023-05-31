using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.OrderModule.Repertories
{
    public class OrderRepository : IOrderRepository
    {
        private SugarSharkDbContext dbContext;

        public OrderRepository(SugarSharkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
