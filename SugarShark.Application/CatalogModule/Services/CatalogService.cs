using AutoMapper;
using SugarShark.Application.CatalogModule.Dtos;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CatalogService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<ProductDto> GetProductById(int id)
        {
            var product= _productRepository.GetProductById(id);
            var dto=product==null?null:_mapper.Map<ProductDto>(product);

            return Task.FromResult(dto);
        }

        public Task<List<ProductDto>> GetProducts()
        {
            var products = _productRepository.GetProducts().ToList();
            var productDtos=_mapper.Map<List<ProductDto>>(products);

            return Task.FromResult(productDtos);
        }
        public Task<List<ProductDto>> GetProducts(string type)
        {
            var allProducts= _productRepository.GetProducts();
            var filteredProducts=allProducts.Where(x=>x.ProductType.Name.Equals(type)).ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(filteredProducts);

            return Task.FromResult(productDtos);
        }
        public Task<List<ProductDto>> GetProducts(string type,string name)
        {
            var allProducts = _productRepository.GetProducts();
            var filteredProducts = allProducts.Where(x => x.ProductType.Name.Equals(type) && x.Name.Equals(name)).ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(filteredProducts);

            return Task.FromResult(productDtos);
        }
    }
}
