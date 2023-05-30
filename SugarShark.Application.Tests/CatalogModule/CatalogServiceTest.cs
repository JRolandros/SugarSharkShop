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
using SugarShark.Application.Common;
using Microsoft.EntityFrameworkCore;
using SugarShark.Infrastructure.CatalogModule.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

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
        [Trait("CatalogService","Application level")]
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
        [Trait("CatalogService", "Application level")]
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
        [Trait("CatalogService", "Application level")]
        public async void GetProducts_with_2_arguments_should_return_1_productDto_of_Type_Dark_and_name_of_Juice()
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

        [Fact]
        [Trait("CatalogService", "Application level")]
        public async void when_GetProduct_with_param_1_should_return_one_dto_whose_id_is_1()
        {
            //Arrange
            var product1 = _fixture.Create<Product>();
            product1.Id= 1;
            var products = _fixture.CreateMany<Product>(3);
            var allProducts = new List<Product> { product1 };
            allProducts.AddRange(products);
            var data = allProducts.AsQueryable();
            var dbContext = new Mock<ISugarSharkDbContext>();
            var setMock=new Mock<DbSet<Product>>();
            //setMock.Object.AddRange(allProducts);

            setMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            setMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            setMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            setMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            dbContext.Setup(d => d.Products).Returns(setMock.Object);
            IProductRepository repo = new ProductRepository(dbContext.Object);
            var catalogService = new CatalogService(repo, _mapper);

            //Act
            ProductDto dto = await catalogService.GetProductById(1);

            //Assert
            Assert.Equal(product1.Id, dto.Id);
            Assert.Equal(product1.Image, dto.Image);
            Assert.Equal(product1.Name, dto.Name);
        }
    }

}
