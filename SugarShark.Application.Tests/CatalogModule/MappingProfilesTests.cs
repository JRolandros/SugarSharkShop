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
        [Fact]
        [Trait("MappingTests", "")]
        public void ProductProfile_Should_ProductDto_From_Product()
        {
            //Arrange
            var container = new FakeContainerManager();
            var services = container.Services;

            services.AddApplication(); // should add Automapper profiles that have to be tested

            var provider = container.GetServiceProvider();

            Fixture fixture =new Fixture();
            var fakeProduct = fixture.Create<Product>();

            var mapper = provider.GetService<IMapper>();

            //Act
            var dto=mapper.Map<ProductDto>(fakeProduct);

            //Assert
            Assert.Equal(fakeProduct.Image, dto.Image);
            Assert.Equal(fakeProduct.ProductType.Name, dto.Type);


        }

        
    }
}
