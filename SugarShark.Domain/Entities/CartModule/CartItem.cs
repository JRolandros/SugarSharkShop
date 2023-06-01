
namespace SugarShark.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
