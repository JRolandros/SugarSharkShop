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
        public PlaceOrderCommand(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }

        //TODO : Add payment and shipping information here
    }
}