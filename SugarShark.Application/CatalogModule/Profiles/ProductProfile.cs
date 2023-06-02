using AutoMapper;
using SugarShark.Application.CatalogModule.Dtos;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForPath(dest => dest.ProductType.Name, act => act.MapFrom(src => src.Type))
                .ReverseMap();

            CreateMap<Product, CatalogItemDto>()
                .ForMember(dest => dest.MaxQty, act => act.MapFrom(src => src.Stock))
                .ForPath(dest => dest.Type, act => act.MapFrom(src => src.ProductType.Name));
        }
    }
}
