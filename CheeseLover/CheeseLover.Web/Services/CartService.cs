using CheeseLover.Shared.Models;
using System.Text;
using System.Text.Json;

namespace CheeseLover.Web.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateCart()
        {
            var response = await _httpClient.PostAsync("api/cart", null);

            if (response.IsSuccessStatusCode)
            {
                var responses = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<int>(responses);
            }

            return 0;
        }

        public async Task<Cart> GetCartById(string id)
        {
            return await JsonSerializer.DeserializeAsync<Cart>
                (await _httpClient.GetStreamAsync($"api/cart/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task AddCheeseToCart(CartItemVM item)
        {
            var cheeseJson = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/cart/add", cheeseJson);
        }
    }
}
