using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, int>
    {
        public Task<int> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
