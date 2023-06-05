using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CartModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, int>
    {
        private readonly ILogger<DeleteCartItemCommandHandler> _logger;
        private readonly ICartService _cartService;

        public DeleteCartItemCommandHandler(ILogger<DeleteCartItemCommandHandler> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }


        public async Task<int> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Debut DeleteCartItem handler");

            int ok = await _cartService.DeleteCartItem(request.ProductId, request.UserId);

            _logger.LogInformation("Fin DeleteCartItem handler");

            return ok;
        }
    }
}
