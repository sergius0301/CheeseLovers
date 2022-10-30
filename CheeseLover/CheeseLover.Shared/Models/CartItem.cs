using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseLover.Shared.Models
{
    public class CartItem : BaseModel
    {
        public Cheese Cheese { get; set; }  
        public decimal Quantity { get; set; }
    }
}
