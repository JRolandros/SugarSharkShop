using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Commands
{
    public class ChangeCartItemQtyCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int UserId { get; set; }
    }
}
