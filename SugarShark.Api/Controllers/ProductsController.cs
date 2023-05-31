using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugarShark.Application.CatalogModule.Queries.GetProduct;
using SugarShark.Application.CatalogModule.Queries.GetProducts;

namespace SugarShark.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetCatalog()
        {
            var resp = await _mediator.Send(new GetCatalogQuery());

            return Ok(resp.Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var resp = await _mediator.Send(new GetProductQuery(id));

            return Ok(resp);
        }
    }
}
