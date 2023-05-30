using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugarShark.Application.CatalogModule.Queries.GetProducts;

namespace SugarShark.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
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
    }
}
