namespace SugarShark.Application.CartModule.Dtos
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
}