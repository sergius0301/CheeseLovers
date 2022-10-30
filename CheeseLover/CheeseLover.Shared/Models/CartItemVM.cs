using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseLover.Shared.Models
{
    public class CartItemVM
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public decimal Quantity { get; set; }
    }
}
