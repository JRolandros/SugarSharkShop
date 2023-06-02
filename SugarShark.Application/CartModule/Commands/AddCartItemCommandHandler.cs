using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CartModule.Queries;
using SugarShark.Application.CartModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, int>
    {
        private readonly ILogger<AddCartItemCommandHandler> _logger;
        private readonly ICartService _cartService;

        public AddCartItemCommandHandler(ILogger<AddCartItemCommandHandler> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<int> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Debut AddCartItem handler");

            int ok = await _cartService.AddCartItem(request.ProductId, request.UserId);

            _logger.LogInformation("Fin AddCartItem handler");

            return ok;
        }
    }
}
