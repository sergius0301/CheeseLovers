namespace CheeseLover.Shared.Models
{
    public class Cart
    {
        public List<Cheese> Cheeses { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
