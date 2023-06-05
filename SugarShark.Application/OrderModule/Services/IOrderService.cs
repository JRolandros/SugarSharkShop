using SugarShark.Application.OrderModule.Dtos;

namespace SugarShark.Application.OrderModule.Services
{
    public interface IOrderService
    {
        Task<int> PlaceOrder(OrderDto order);
    }
}