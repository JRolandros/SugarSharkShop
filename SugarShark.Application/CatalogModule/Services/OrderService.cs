using AutoMapper;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository @object;
        private IMapper? mapper;

        public OrderService(IOrderRepository @object, IMapper? mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }

        public int PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
