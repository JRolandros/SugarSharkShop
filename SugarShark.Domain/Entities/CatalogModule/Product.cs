
namespace SugarShark.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
