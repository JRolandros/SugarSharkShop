
namespace SugarShark.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public Address DeliveryAddress { get; set; }
    }

    
}
