using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugarShark.Application.CartModule.Commands;
using SugarShark.Application.CartModule.Queries;
using SugarShark.Domain.Entities;

namespace SugarShark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly IMediator _mediator;

        public CartController(ILogger<CartController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Debut GetCart endpoint");

            var cart=await _mediator.Send(new GetCartQuery() { UserId=1});

            _logger.LogInformation("Fin GetCart endpoint");

            return Ok(cart.CartItemDtos);
        }
      

        [HttpPut]
        public async Task<IActionResult> AddCartItem(int productId)
        {
            _logger.LogInformation("Debut AddCartItem endpoint");

            var ok = await _mediator.Send(new AddCartItemCommand() { ProductId = productId, UserId = 1 });

            _logger.LogInformation("Fin AddCartItem endpoint");

            return Ok(ok);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeCartItemQty(int productId,int newQty)
        {
            _logger.LogInformation("Debut ChangeCartItemQty endpoint");

            var ok = await _mediator.Send(new ChangeCartItemQtyCommand() { ProductId = productId, UserId = 1, Qty=newQty });

            _logger.LogInformation("Fin ChangeCartItemQty endpoint");

            return Ok(ok);
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            _logger.LogInformation("Debut RemoveFromCart endpoint");

            var ok = await _mediator.Send(new DeleteCartItemCommand() { ProductId = productId, UserId = 1 });

            _logger.LogInformation("Fin RemoveFromCart endpoint");

            return Ok(ok);
        }
    }
}
