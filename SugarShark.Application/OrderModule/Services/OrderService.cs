using AutoMapper;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Application.OrderModule.Dtos;
using SugarShark.Application.OrderModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper? _mapper;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IMapper? mapper)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Task<int> PlaceOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            var cart = _cartRepository.GetCart(order.UserId,true);

            bool hasItems=cart.CartItems.Any();

            if (!hasItems)
                throw new InvalidOperationException("Votre panier est vide");

            order.OrderStatus = (int)OrderStatus.OrderPaid;

            int ok = _orderRepository.PlaceOrder(order);

            if(ok == 1)
            {
                ok=_cartRepository.DeleteCart(order.UserId);
            }

            return Task.FromResult(ok);
        }
    }
}
