using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.OrderModule.Repositories;
using SugarShark.Application.OrderModule.Services;
using SugarShark.Domain.Entities;
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

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }


        [Fact]
        [Trait("ApplicationServices", "Order")]
        public void when_PlaceOrder_and_cart_exist_should_return_1()
        {
            //Arrange
            var order = _fixture.Create<Order>();
            Mock<IOrderRepository> repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(x => x.PlaceOrder(It.IsAny<Order>())).Returns(1);

            var service = new OrderService(repoMock.Object, _mapper);

            //Act
            int actual =service.PlaceOrder(order);

            //Assert
            actual.Should().Be(1);
            repoMock.Verify(x=>x.PlaceOrder(It.IsAny<Order>()),Times.Once);
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
