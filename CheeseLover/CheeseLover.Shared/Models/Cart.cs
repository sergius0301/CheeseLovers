namespace CheeseLover.Shared.Models
{
    public class Cart: BaseModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
