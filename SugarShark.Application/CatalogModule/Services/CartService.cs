using AutoMapper;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Services
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
            var cart=_cartRepository.GetCart(userId);

            return cart;
        }
    }
}
