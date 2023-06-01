using SugarShark.Application.Common;
using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule.Dtos
{
    public class OrderDto :BaseDto
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
