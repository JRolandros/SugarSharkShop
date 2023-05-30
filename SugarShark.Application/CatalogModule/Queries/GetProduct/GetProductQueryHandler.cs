using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CatalogModule.Dtos;
using SugarShark.Application.CatalogModule.Queries.GetProducts;
using SugarShark.Application.CatalogModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly ILogger<GetCatalogQueryHandler> _logger;
        private readonly ICatalogService _catalogService;

        public GetProductQueryHandler(ILogger<GetCatalogQueryHandler> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var dto = await _catalogService.GetProductById(request.Id);

            return dto;
        }
    }
}
