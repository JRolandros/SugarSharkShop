using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CatalogModule.Dtos;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.CatalogModule.Services;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Queries.GetProducts
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, Catalog>
    {
        private readonly ILogger<GetCatalogQueryHandler> _logger;
        private readonly ICatalogService _catalogService;

        public GetCatalogQueryHandler(ILogger<GetCatalogQueryHandler> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }
        public async Task<Catalog> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            List<ProductDto> productDtos = null;

            if (!string.IsNullOrEmpty(request.Type))
            {
                if(!string.IsNullOrEmpty(request.Name))
                {
                    productDtos=await _catalogService.GetProducts(request.Type,request.Name);
                }
                else
                {
                    productDtos = await _catalogService.GetProducts(request.Type);
                }
            }
            else
            {
                productDtos = await _catalogService.GetProducts();
            }


            return new Catalog() { Products = productDtos };

        }
    }
}
