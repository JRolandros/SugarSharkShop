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
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public Address DeliveryAddress { get; set; }
    }

    public enum OrderStatus
    {
        OrderCreated = 1,
        OrderPaid = 2,
        OrderComplete = 3,
        OrderSent = 4
    }
}
