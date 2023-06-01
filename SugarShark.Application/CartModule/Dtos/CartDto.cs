using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule.Dtos
{
    public class CartDto
    {
        public DateTime ValidityEndDate { get; set; }
        public int UserId { get; set; }

        public List<CartItemDto> CartItems { get; set; }
    }
}
