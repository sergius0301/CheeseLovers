using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Services
{
    public interface ICheeseService
    {
        void CreateCheese(Cheese cheese);
        bool DeleteCheeseById(int id);
        List<Cheese> GetAll();
        Cheese GetCheeseById(int id);
        bool UpdateCheese(Cheese cheese);
    }
}