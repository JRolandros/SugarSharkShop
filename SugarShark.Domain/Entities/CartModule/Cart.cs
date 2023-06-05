
namespace SugarShark.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems=new List<CartItem>();
        }
        public DateTime ValidityEndDate { get; set; }
        public int UserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
