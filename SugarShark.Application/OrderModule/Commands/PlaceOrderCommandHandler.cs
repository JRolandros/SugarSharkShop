using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.OrderModule.Dtos;
using SugarShark.Application.OrderModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule.Commands
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, int>
    {
        private readonly ILogger<PlaceOrderCommandHandler> _logger;
        private readonly IOrderService _orderService;

        public PlaceOrderCommandHandler(ILogger<PlaceOrderCommandHandler> logger,IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        public async Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Debut PlaceOrder handler");

            var order=new OrderDto() { UserId=request.UserId, OrderDate=DateTime.Now,OrderStatus=(int)OrderStatus.OrderCreated };
            int saved = await _orderService.PlaceOrder(order);

            _logger.LogInformation("Fin PlaceOrder handler");

            return saved;
        }
    }
}
