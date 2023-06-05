using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Domain.Common
{
    public class CartItemProxy
    {
        public CartItem CartItem { get; set; }
        public Product Product { get; set; }
    }
}
