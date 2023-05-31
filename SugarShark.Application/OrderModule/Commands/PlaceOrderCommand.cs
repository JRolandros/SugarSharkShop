using MediatR;
using SugarShark.Domain.Entities;

namespace SugarShark.Application.OrderModule.Commands
{
    public class PlaceOrderCommand :IRequest<int>
    {
    }
}