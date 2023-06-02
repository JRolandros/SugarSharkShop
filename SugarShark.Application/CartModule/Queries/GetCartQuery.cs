using MediatR;
using SugarShark.Application.CartModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Queries
{
    public class GetCartQuery :IRequest<CartDto>
    {
        public int UserId { get; set; }
    }
}
