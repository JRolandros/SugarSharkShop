using AutoMapper;
using SugarShark.Application.CartModule.Dtos;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Application.CatalogModule.Repositories;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper? _mapper;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IMapper? mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<CartDto> GetCart(int userId)
        {
            var cart = _cartRepository.GetCart(userId);
            var cartDto = _mapper.Map<CartDto>(cart);

            var cartItemProxy=_cartRepository.GetCartItemsWithProducts(cart.Id);
            var items = _mapper.Map<List<CartItemDto>>(cartItemProxy);

            cartDto.CartItemDtos = items;

            return Task.FromResult(cartDto);
        }

        public Task<int> UpdateCartItemQty(int productId,int userId, int quantity)
        {
            int ok = 0;

            var cart = _cartRepository.GetCart(userId);

            if (quantity <= 0)
            {
                ok=_cartRepository.DeleteCartItem(productId, cart.Id);
            }
            else
            {
                ok = _cartRepository.UpdateCartItemQty(productId, cart.Id, quantity);
            }            

            return Task.FromResult(ok);
        }

        public Task<int> AddCartItem(int productId,int userId)
        {
            var cart=_cartRepository.GetCart(userId);

            CartItem cartItem = _cartRepository.GetCartItemByProductIdCartId(productId, cart.Id);
            int ok = 0;

            if (cartItem != null)
            {
                cartItem.Quantity++;

                ok=_cartRepository.UpdateCartItem(cartItem);
            }
            else
            {
                cartItem = new CartItem() { CartId = cart.Id, ProductId = productId, Quantity = 1 };
                ok = _cartRepository.AddCartItem(cartItem);
            }           

            return Task.FromResult(ok);
        }

        public Task<int> DeleteCartItem(int productId,int userId)
        {
            Cart cart = _cartRepository.GetCart(userId);

            int ok = _cartRepository.DeleteCartItem(productId,cart.Id);

            return Task.FromResult(ok);
        }
    }
}
