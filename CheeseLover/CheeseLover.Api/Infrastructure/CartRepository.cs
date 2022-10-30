using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly ApiContext _dbContext;

        public CartRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create()
        {
            var cart = new Cart { CartItems = new List<CartItem>() };

            var lastId = _dbContext.Cart.LastOrDefault()?.Id;
            cart.Id = lastId.HasValue ? lastId.Value + 1 : 0;

            _dbContext.Add(cart);

            SaveChanges();

            return cart.Id;
        }

        public void AddItemsToCart(int cartId, CartItem item)
        {
            var cart = _dbContext.Cart.FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                cart.CartItems.Add(item);

                SaveChanges();
            }
        }
        public Cart GetCartById(int id)
        {
            return _dbContext.Cart.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
