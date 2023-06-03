using AutoFixture;
using FluentAssertions;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.CatalogModule.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.Tests.CatalogModule
{
    public class ProductRepositoryTest
    {
        private readonly SugarSharkDbContext _dbContext;
        private readonly Fixture _fixture;
        public ProductRepositoryTest()
        {
            _dbContext=SugarSharkInMemoryDbContext.GetSugarSharkDbContext();

            _fixture = new Fixture();
        }

        [Fact]
        [Trait("Repositories", "Catalog")]
        public void when_GetProducts_should_return_all_products()
        {
            //Arrange
            //var expectedProducts = _fixture.CreateMany<Product>();
            //_dbContext.Products.AddRange(expectedProducts);
            //_dbContext.SaveChanges();

            var repo = new ProductRepository(_dbContext);

            //Act
            var actualProducts=repo.GetProducts();

            actualProducts.Should().NotBeEmpty();

        }

        [Theory]
        [Trait("Repositories", "Catalog")]
        [InlineData(12)]
        public void when_GetProductById_with_arg_1_should_return_one_product_of_id_1(int productId)
        {
            //Arrange

            var repo = new ProductRepository(_dbContext);

            //Act
            var actualProduct = repo.GetProductById(productId);

            //Assert
            actualProduct.Id.Should().Be(productId);
        }
    }
}
