using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.CatalogModule.Services;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Tests.CatalogModule
{
    public class CartServiceTests
    {
        private readonly Fixture _fixture;
        private readonly FakeContainerManager _container;
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;
        private readonly IMapper? _mapper;

        public CartServiceTests()
        {
            _fixture = new Fixture();
            _container = new FakeContainerManager();
            _services = _container.Services;

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }


        [Fact]
        [Trait("ApplicationServices", "Order")]
        public void when_GetCart_and_cart_exist_should_return_cart()
        {
            //Arrange
            var expected = _fixture.Create<Cart>();

            Mock<ICartRepository> repoMock= new Mock<ICartRepository>();
            repoMock.Setup(x=>x.GetCart(It.IsAny<int>())).Returns(expected);

            var service = new CartService(repoMock.Object, _mapper);

            //Act
            Cart actual = service.GetCart(expected.UserId);

            //Assert
            actual.CartItems.Should().NotBeNull().And.NotBeEmpty();
            actual.Should().Be(expected);
        }

    }
}
