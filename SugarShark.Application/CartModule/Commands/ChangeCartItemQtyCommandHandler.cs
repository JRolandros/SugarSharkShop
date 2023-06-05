using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CartModule.Dtos;
using SugarShark.Application.CartModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class ChangeCartItemQtyCommandHandler : IRequestHandler<ChangeCartItemQtyCommand, int>
    {
        private readonly ILogger<ChangeCartItemQtyCommandHandler> _logger;
        private readonly ICartService _cartService;

        public ChangeCartItemQtyCommandHandler(ILogger<ChangeCartItemQtyCommandHandler> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<int> Handle(ChangeCartItemQtyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Debut ChangeCartItemQty handler");

            int ok = await _cartService.UpdateCartItemQty(request.ProductId,request.UserId,request.Qty);

            _logger.LogInformation("Fin ChangeCartItemQty handler");

            return ok;
        }
    }
}
