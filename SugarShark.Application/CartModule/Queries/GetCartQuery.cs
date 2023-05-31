using MediatR;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Queries
{
    public class GetCartQuery :IRequest<Cart>
    {
    }
}
