using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Services
{
    public interface ICartService
    {
        int CreateCart();
        void AddToCart(CartItemVM cartItem);
        Cart GetCartById(int id);
    }
}