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
        /// <summary>
        /// With userId we can retrieve the user cart and collect all products he want to order.
        /// </summary>
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        //public Address ? DeliveryAddress { get; set; }

        //TODO : Add payment and shipping info here.
    }

    public enum OrderStatus
    {
        OrderCreated = 1,
        OrderPaid = 2,
        OrderComplete = 3,
        OrderSent = 4
    }
}
