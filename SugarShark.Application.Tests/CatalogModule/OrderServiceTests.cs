using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Application.OrderModule.Dtos;
using SugarShark.Application.OrderModule.Repositories;
using SugarShark.Application.OrderModule.Services;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.OrderModule.Repertories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Tests.CatalogModule
{

    public class OrderServiceTests
    {
        private readonly Fixture _fixture;
        private readonly FakeContainerManager _container;
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;
        private readonly IMapper? _mapper;

        public OrderServiceTests()
        {
            _fixture = new Fixture();
            _container = new FakeContainerManager();
            _services = _container.Services;

            _services.AddApplication();

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }


        [Fact]
        [Trait("ApplicationServices", "Order")]
        public async void when_PlaceOrder_and_cart_exist_should_return_1()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.UserId = 2;

            var order = _fixture.Create<OrderDto>();
            order.UserId = 2;

            Mock<ICartRepository> cartRepoMock = new Mock<ICartRepository>();
            cartRepoMock.Setup(x => x.GetCart(It.IsAny<int>(), It.IsAny<bool>())).Returns(cart);
            cartRepoMock.Setup(x => x.DeleteCart(It.IsAny<int>())).Returns(1);

            Mock<IOrderRepository> repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(x => x.PlaceOrder(It.IsAny<Order>())).Returns(1);

            var service = new OrderService(repoMock.Object,cartRepoMock.Object, _mapper);

            //Act
            int actual =await service.PlaceOrder(order);

            //Assert
            actual.Should().Be(1);
            repoMock.Verify(x=>x.PlaceOrder(It.IsAny<Order>()),Times.Once);
        }

        [Fact]
        [Trait("Repositories", "Order")]
        public async void when_PlaceOrder_and_cartId_not_exist_invalidOperationException()
        {
            //Arrange
            var cart = new Cart();
            var order = _fixture.Create<OrderDto>();
            order.Id = 2;
            order.UserId = 2;

            Mock<IOrderRepository> orderRepoMock = new Mock<IOrderRepository>();
            Mock<ICartRepository> cartRepoMock = new Mock<ICartRepository>();
            cartRepoMock.Setup(x => x.GetCart(It.IsAny<int>(),It.IsAny<bool>())).Returns(cart);

            var service = new OrderService(orderRepoMock.Object, cartRepoMock.Object, _mapper);

            //Act
            var act = async () =>  await service.PlaceOrder(order);

            //Assert
            (await act.Should().ThrowExactlyAsync<InvalidOperationException>()).Which.Message.Should().Be("Votre panier est vide");

        }


        //[Fact]
        //[Trait("ApplicationServices", "Order")]
        //public void when_PlaceOrder_and_no_cart_exist_should_return_invalidOperationException_with_message()
        //{
        //    //Arrange
        //    var order = _fixture.Create<Order>();
        //    Mock<IOrderRepository> repoMock = new Mock<IOrderRepository>();
        //    repoMock.Setup(x=>x.PlaceOrder(It.IsAny<Order>())).Throws<InvalidOperationException>();

        //    var service = new OrderService(repoMock.Object, _mapper);

        //    //Act
        //    var act = () => service.PlaceOrder(order);
        //}

    }
}
