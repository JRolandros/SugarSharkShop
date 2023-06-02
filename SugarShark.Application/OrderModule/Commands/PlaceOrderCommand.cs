using MediatR;
using SugarShark.Application.OrderModule.Dtos;
using SugarShark.Domain.Entities;

namespace SugarShark.Application.OrderModule.Commands
{
    public class PlaceOrderCommand :IRequest<int>
    {
        public PlaceOrderCommand()
        {
            
        }
        public PlaceOrderCommand(OrderDto orderDto)
        {
            Order = orderDto;
        }
        public OrderDto Order { get; set; }
    }
}