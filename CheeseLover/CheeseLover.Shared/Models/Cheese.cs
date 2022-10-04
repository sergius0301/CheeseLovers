using CheeseLover.Shared.Enums;

namespace CheeseLover.Shared.Models
{
    public class Cheese : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CheeseType Category { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }
}
