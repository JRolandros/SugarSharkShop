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
        private ICartRepository @object;
        private IMapper? mapper;

        public CartService(ICartRepository @object, IMapper? mapper)
        {
            this.@object = @object;
            this.mapper = mapper;
        }

        public Cart GetCart(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
