using SugarShark.Application.CartModule.Dtos;

namespace SugarShark.Application.CartModule.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCart(int userId);

        Task<int> UpdateCartItemQty(int productId, int userId, int quantity);

        Task<int> AddCartItem(int productId, int userId);

        Task<int> DeleteCartItem(int productId, int userId);
    }
}