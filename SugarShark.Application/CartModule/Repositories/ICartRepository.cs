using SugarShark.Domain.Common;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Repositories
{
    public interface ICartRepository
    {
        CartItem GetCartItemById(int id);
        int AddCartItem(CartItem cartItem);
        int DeleteCartItem(int productId, int cartId);
        Cart GetCart(int userId, bool includeItems = false);
        int DeleteCart(int userId);
        IEnumerable<CartItemProxy> GetCartItemsWithProducts(int cartId);
        int UpdateCartItemQty(int productId, int cartId, int quantity);
        int UpdateCartItem(CartItem item);
        CartItem GetCartItemByProductIdCartId(int productId, int cartId);
    }
}
