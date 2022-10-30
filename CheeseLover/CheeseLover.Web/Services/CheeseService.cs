using CheeseLover.Shared.Models;
using System.Text;
using System.Text.Json;

namespace CheeseLover.Web.Services
{
    public class CheeseService
    {
        private readonly HttpClient _httpClient;
        public CheeseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Cheese>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<List<Cheese>>
                (await _httpClient.GetStreamAsync($"api/cheese"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Cheese> GetCheeseById(int cheeseId)
        {
            return await JsonSerializer.DeserializeAsync<Cheese>
                (await _httpClient.GetStreamAsync($"api/cheese/{cheeseId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task RemoveCheese(int id)
        {
            await _httpClient.DeleteAsync($"api/cheese/{id}");
        }

        public async Task UpdateCheese(Cheese cheese)
        {
            var cheeseJson =
                new StringContent(JsonSerializer.Serialize(cheese), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/cheese", cheeseJson);
        }

        public async Task AddCheese(Cheese cheese)
        {
            var cheeseJson = new StringContent(JsonSerializer.Serialize(cheese), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("api/cheese", cheeseJson);
        }
    }
}
