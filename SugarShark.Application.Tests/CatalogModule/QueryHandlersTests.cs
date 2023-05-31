using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SugarShark.Application.CatalogModule.Queries.GetProduct;
using SugarShark.Application.CatalogModule.Queries.GetProducts;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.CatalogModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Tests.CatalogModule
{
    public class QueryHandlersTests
    {
        private readonly FakeContainerManager _container;
        private readonly IServiceCollection _services;
        public QueryHandlersTests()
        {
            _container = new FakeContainerManager();
            _services = _container.Services;

            _services.AddLogging();
            _services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetCatalogQueryHandler).Assembly));

        }

        [Fact]
        [Trait("GetCatalog", "Application level")]
        public async void when_GetCatalogQuery_is_Send_with_no_param_GetProducts_with_no_param_is_hit()
        {
            //Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            _services.AddScoped(provider => catalogServiceMock.Object);

            var provider = _container.GetServiceProvider();

            var mediator = provider.GetService<IMediator>();

            //Act
            await mediator.Send(new GetCatalogQuery());

            //Assert
            catalogServiceMock.Verify(x => x.GetProducts(), Times.Once);
            catalogServiceMock.Verify(x => x.GetProducts(It.IsAny<string>()), Times.Never);
            catalogServiceMock.Verify(x => x.GetProducts(It.IsAny<string>(), It.IsAny<string>()), Times.Never);

        }

        [Fact]
        [Trait("GetCatalog","Application level")]
        public async void when_GetCatalogQuery_is_Send_with_type_param_GetProducts_with_one_param_is_hit()
        {
            //Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            _services.AddScoped(provider => catalogServiceMock.Object);

            var provider=_container.GetServiceProvider();

            var mediator=provider.GetService<IMediator>();

            //Act
            await mediator.Send(new GetCatalogQuery() { Type = "Dark" });

            //Assert
            catalogServiceMock.Verify(x=>x.GetProducts(It.IsAny<string>()),Times.Once);
            catalogServiceMock.Verify(x => x.GetProducts(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            catalogServiceMock.Verify(x => x.GetProducts(), Times.Never);

        }

        [Fact]
        [Trait("GetCatalog", "Application level")]
        public async void when_GetCatalogQuery_is_Send_with_2_param_GetProducts_with_2_param_is_hit()
        {
            //Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            _services.AddScoped(provider => catalogServiceMock.Object);

            var provider = _container.GetServiceProvider();

            var mediator = provider.GetService<IMediator>();

            //Act
            await mediator.Send(new GetCatalogQuery() { Type = "Dark",Name="test" });

            //Assert
            catalogServiceMock.Verify(x => x.GetProducts(It.IsAny<string>(),It.IsAny<string>()), Times.Once);
            catalogServiceMock.Verify(x => x.GetProducts(It.IsAny<string>()), Times.Never);
            catalogServiceMock.Verify(x => x.GetProducts(), Times.Never);

        }

        [Fact]
        [Trait("GetProduct", "Application level")]
        public async void when_GetProductQuery_is_Send_GetProductById_is_hit()
        {
            //Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            _services.AddScoped(provider => catalogServiceMock.Object);

            var provider = _container.GetServiceProvider();

            var mediator = provider.GetService<IMediator>();

            //Act
            await mediator.Send(new GetProductQuery(1));

            //Assert
            catalogServiceMock.Verify(x => x.GetProductById(It.IsAny<int>()), Times.Once);

        }


    }
}
