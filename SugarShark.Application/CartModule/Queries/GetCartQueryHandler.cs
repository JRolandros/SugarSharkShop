using MediatR;
using Microsoft.Extensions.Logging;
using SugarShark.Application.CartModule.Dtos;
using SugarShark.Application.CartModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
    {
        private readonly ILogger<GetCartQueryHandler> _logger;
        private readonly ICartService _cartService;

        public GetCartQueryHandler(ILogger<GetCartQueryHandler> logger,ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }
        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Debut GetCart handler");

            CartDto cart = await _cartService.GetCart(request.UserId);

            _logger.LogInformation("Fin GetCart handler");

            return cart;

        }
    }
}
