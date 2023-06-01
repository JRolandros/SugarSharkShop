using AutoMapper;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper? _mapper;

        public CartService(ICartRepository cartRepository, IMapper? mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Cart GetCart(int userId)
        {
            var cart = _cartRepository.GetCart(userId);

            return cart;
        }

        public int UpdateCartItemQty(int itemId, int quantity)
        {
            return _cartRepository.UpdateCartItemQty(itemId, quantity);
        }

        public int AddCartItem(CartItem cartItem)
        {
            return _cartRepository.AddCartItem(cartItem);
        }

        public int DeleteCartItem(int itemId)
        {
            return _cartRepository.DeleteCartItem(itemId);
        }
    }
}
