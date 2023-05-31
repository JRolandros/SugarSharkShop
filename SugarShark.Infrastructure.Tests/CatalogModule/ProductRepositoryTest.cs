using AutoFixture;
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
        public void when_GetProducts_should_return_all_products()
        {
            //Arrange
            var expectedProducts = _fixture.CreateMany<Product>();
            _dbContext.Products.AddRange(expectedProducts);
            _dbContext.SaveChanges();

            var repo = new ProductRepository(_dbContext);

            //Act
            var actualProducts=repo.GetProducts();

            Assert.Equal(expectedProducts, actualProducts);
        }

        [Fact]
        public void when_GetProductById_with_arg_1_should_return_one_product_of_id_1()
        {
            //Arrange
            var allProducts = _fixture.CreateMany<Product>(3).ToList();
            var expectedProduct = new Product { Id = 1, Name = "Test", Image="",Price=20,ProductType=null };
            allProducts.Add(expectedProduct);
            _dbContext.Products.AddRange(allProducts);
            _dbContext.SaveChanges();

            var repo = new ProductRepository(_dbContext);

            //Act
            var actualProduct = repo.GetProductById(1);

            Assert.Equal(expectedProduct, actualProduct);
        }
    }
}
