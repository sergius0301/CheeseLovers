using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Infrastructure
{
    public interface ICartRepository
    {
        void AddItemsToCart(int cartId, CartItem item);
        int Create();
        void SaveChanges();
        Cart GetCartById(int id);
    }
}