using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CartModule.Dtos;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Application.CartModule.Services;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.OrderModule.Repositories;
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

            _services.AddApplication();

            _provider = _container.GetServiceProvider();
            _mapper = _provider.GetService<IMapper>();
        }


        [Fact]
        [Trait("ApplicationServices", "Order")]
        public async void when_GetCart_and_cart_exist_should_return_cart()
        {
            //Arrange
            var expected = _fixture.Create<Cart>();

            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();
            Mock<ICartRepository> repoMock= new Mock<ICartRepository>();
            repoMock.Setup(x=>x.GetCart(It.IsAny<int>(),It.IsAny<bool>())).Returns(expected);

            var service = new CartService(repoMock.Object,productRepoMock.Object, _mapper);

            //Act
            CartDto actual = await service.GetCart(expected.UserId);
            var expectedDto = _mapper.Map<CartDto>(expected);
            //Assert
            //actual.CartItems.Should().NotBeNull().And.NotBeEmpty();
            actual.UserId.Should().Be(expectedDto.UserId);
            actual.ValidityEndDate.Should().Be(expectedDto.ValidityEndDate);
            repoMock.Verify(x => x.GetCart(It.IsAny<int>(), It.IsAny<bool>()), Times.Once);
        }

    }
}
