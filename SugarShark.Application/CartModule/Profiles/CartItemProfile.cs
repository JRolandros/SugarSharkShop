using AutoMapper;
using SugarShark.Application.CartModule.Dtos;
using SugarShark.Domain.Common;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Qty, act => act.MapFrom(src => src.Quantity)).ReverseMap();

            CreateMap<CartItemProxy, CartItemDto>()
                .ForPath(dest => dest.Qty, act => act.MapFrom(src => src.CartItem.Quantity))
                .ForPath(dest => dest.Price, act => act.MapFrom(src => src.Product.Price))
                .ForPath(dest => dest.Name, act => act.MapFrom(src => src.Product.Name))
                .ForPath(dest => dest.ProductId, act => act.MapFrom(src => src.CartItem.ProductId))
                .ForPath(dest => dest.Image, act => act.MapFrom(src => src.Product.Image));


        }
    }
}
