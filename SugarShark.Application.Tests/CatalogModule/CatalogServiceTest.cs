using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.CatalogModule.Services;
using SugarShark.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SugarShark.Application.CatalogModule.Dtos;

namespace SugarShark.Application.Tests.CatalogModule
{
    public class CatalogServiceTest
    {
        private readonly Fixture _fixture;
        private readonly FakeContainerManager _container;
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;
        private readonly IMapper? _mapper;

        public CatalogServiceTest()
        {
            _fixture = new Fixture();
            _container = new FakeContainerManager();
            _services = _container.Services;

            _services.AddApplication(); // should add Automapper profiles that have to be tested

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }

        [Fact]
        public async void GetProducts_should_return_all_productDto()
        {
            //Arrange
            var products = _fixture.CreateMany<Product>(10);
            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(x => x.GetProducts()).Returns(products);
            var catalogService = new CatalogService(repoMock.Object, _mapper);

            //Act
            var dtos = await catalogService.GetProducts();

            //Assert
            dtos.Should().NotBeNull().And.NotBeEmpty();
            Assert.IsType<ProductDto>(dtos.First());
            Assert.Equal(products.Count(), dtos.Count());

        }

        [Fact]
        public async void GetProducts_with_Type_argument_should_return_2_productDto_of_Type_Dark()
        {
            //Arrange
            var product1 = _fixture.Create<Product>();
            product1.ProductType.Name = "Dark";
            var product2 = _fixture.Create<Product>();
            product2.ProductType.Name = "Clear";
            var product3 = _fixture.Create<Product>();
            product3.ProductType.Name = "Dark";
            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(x => x.GetProducts()).Returns(new List<Product> { product1, product2, product3 });
            var catalogService = new CatalogService(repoMock.Object, _mapper);

            //Act
            var dtos = await catalogService.GetProducts("Dark");

            //Assert
            dtos.Should().NotBeNull().And.NotBeEmpty();
            Assert.IsType<ProductDto>(dtos.First());
            Assert.Equal(2, dtos.Count());
            Assert.True(dtos.Any(x => x.Type == "Dark"));
        }

        [Fact]
        public async void GetProducts_with_Type_argument_should_return_1_productDto_of_Type_Dark_and_name_of_Juice()
        {
            //Arrange
            var product1 = _fixture.Create<Product>();
            product1.ProductType.Name = "Clear";
            var product2 = _fixture.Create<Product>();
            product2.ProductType.Name = "Dark";
            product2.Name = "Juice";
            var product3 = _fixture.Create<Product>();
            product3.ProductType.Name = "Dark";
            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(x => x.GetProducts()).Returns(new List<Product> { product1, product2, product3 });
            var catalogService = new CatalogService(repoMock.Object, _mapper);

            //Act
            var dtos = await catalogService.GetProducts("Dark", "Juice");

            //Assert
            dtos.Should().NotBeNull().And.NotBeEmpty();
            Assert.IsType<ProductDto>(dtos.First());
            Assert.Equal(1, dtos.Count());
            Assert.Equal("Dark", dtos.First().Type);
            Assert.Equal("Juice", dtos.First().Name);
        }
    }
}
