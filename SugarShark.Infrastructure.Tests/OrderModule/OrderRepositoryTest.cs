using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.OrderModule.Repertories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.Tests.OrderModule
{
    public class OrderRepositoryTest
    {
        private readonly SugarSharkDbContext _dbContext;
        private readonly Fixture _fixture;
        public OrderRepositoryTest()
        {
            _dbContext = SugarSharkInMemoryDbContext.GetSugarSharkDbContext();

            _fixture = new Fixture();
        }

        [Fact]
        [Trait("Repositories","Order")]
        public void when_PlaceOrder_should_save_in_database_and_return_1()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;

            var order = _fixture.Create<Order>();
            order.Id = 2;
            order.CartId = cart.Id;

            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            var repo = new OrderRepository(_dbContext);

            //Act
            int actual=repo.PlaceOrder(order);

            //Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        [Trait("Repositories", "Order")]
        public void when_PlaceOrder_and_cartId_not_exist_invalidOperationException()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;

            var order = _fixture.Create<Order>();
            order.Id = 2;
            order.CartId = 2;

            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            var repo = new OrderRepository(_dbContext);

            //Act
            var act=()=>repo.PlaceOrder(order);

            //Assert
            act.Should().ThrowExactly<InvalidOperationException>().Which.Message.Should().Be("Votre panier est vide");

        }
    }
}
