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
        int AddCartItem(CartItem cartItem);
        int DeleteCartItem(int itemId);
        Cart GetCart(int userId);
        IEnumerable<CartItemProxy> GetCartItemsWithProducts(int cartId);
        int UpdateCartItemQty(int itemId, int quantity);
    }
}
