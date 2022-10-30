using CheeseLover.Api.Infrastructure;
using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICheeseRepository _cheeseRepository;

        public CartService(ICartRepository cartRepository, ICheeseRepository cheeseRepository)
        {
            _cartRepository = cartRepository;
            _cheeseRepository = cheeseRepository;
        }

        public void AddToCart(CartItemVM cartItem)
        {
            var cart = _cartRepository.GetCartById(cartItem.CartId);
            var cheese = _cheeseRepository.GetById(cartItem.ProductId);
            if(cart != null && cheese != null)
            {
                cart.CartItems.Add(new CartItem { Cheese = cheese, Quantity = cartItem.Quantity });
                _cartRepository.SaveChanges();
                RecalculateTotalPrice(cart);
            }
        }

        public int CreateCart()
        {
            return _cartRepository.Create();
        }

        public Cart GetCartById(int id)
        {
            return _cartRepository.GetCartById(id);
        }

        private void RecalculateTotalPrice(Cart cart)
        {
            decimal totalPrice = 0;
            foreach(var item in cart.CartItems)
            {
                totalPrice += item.Cheese.Price * item.Quantity; 
            }

            cart.TotalPrice = totalPrice;
            _cartRepository.SaveChanges();
        }
    }
}
