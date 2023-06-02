using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugarShark.Api.Models;
using SugarShark.Application.OrderModule.Commands;

namespace SugarShark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
        {
            OrderResponse response = new OrderResponse();

            try
            {
                _logger.LogInformation("Debut PlaceOrder endpoint");
                int ok = await _mediator.Send(command);
                response.IsOrderValid = ok == 1 ? true : false;
            }
            catch (Exception ex)
            {
                response.IsOrderValid = false;
                response.addErrorMessage(ex.Message);
                throw;
            }

            
            return Ok(response);
        }
    }
}
