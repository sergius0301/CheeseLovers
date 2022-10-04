using CheeseLover.Shared.Models;
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
        public async Task<List<Cheese>> GetAllPackages()
        {
            return await JsonSerializer.DeserializeAsync<List<Cheese>>
                (await _httpClient.GetStreamAsync($"api/cheese"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
