using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugarShark.Application.Common;

namespace SugarShark.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("error-development")]
        public IActionResult HandleErrorDevelopment()
        {
            return GetProblem();
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return GetProblem();
        }

        private ObjectResult GetProblem()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            _logger.LogError(exception?.Message, exception);

            return Problem(detail: exception?.Message);
        }
    }
}
