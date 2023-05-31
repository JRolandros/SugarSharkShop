using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class ChangeCartItemQtyCommandHandler : IRequestHandler<ChangeCartItemQtyCommand, int>
    {
        public Task<int> Handle(ChangeCartItemQtyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
