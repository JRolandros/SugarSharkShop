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
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper? _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper? mapper)
        {
            _orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public int PlaceOrder(Order order)
        {
            int ok=_orderRepository.PlaceOrder(order);
            return ok;
        }
    }
}
