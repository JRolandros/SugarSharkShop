using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule.Commands
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, int>
    {
        public Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
