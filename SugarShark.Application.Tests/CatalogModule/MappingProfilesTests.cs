using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CatalogModule.Dtos;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Tests.CatalogModule
{
    public class MappingProfilesTests
    {
        private readonly FakeContainerManager _container;
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;
        private readonly IMapper? _mapper;

        public MappingProfilesTests()
        {
            _container = new FakeContainerManager();
            _services = _container.Services;

            _services.AddApplication(); // should add Automapper profiles that have to be tested

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }

        [Fact]
        [Trait("MappingTests", "")]
        public void ProductProfile_Should_ProductDto_From_Product()
        {
            //Arrange                     
            Fixture fixture =new Fixture();
            var fakeProduct = fixture.Create<Product>();

            //Act
            var dto=_mapper.Map<ProductDto>(fakeProduct);

            //Assert
            Assert.Equal(fakeProduct.Image, dto.Image);
            Assert.Equal(fakeProduct.ProductType.Name, dto.Type);
        }

        
    }
}
