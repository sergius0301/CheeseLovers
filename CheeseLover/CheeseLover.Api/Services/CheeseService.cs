using CheeseLover.Api.Infrastructure;
using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Services
{
    public class CheeseService : ICheeseService
    {
        private readonly ICheeseRepository _cheeseRepository;

        public CheeseService(ICheeseRepository cheeseRepository)
        {
            _cheeseRepository = cheeseRepository;
        }
        public List<Cheese> GetAll()
        {
            return _cheeseRepository.Get();
        }

        public Cheese GetCheeseById(int id)
        {
            return _cheeseRepository.GetById(id);
        }

        public bool DeleteCheeseById(int id)
        {
            return _cheeseRepository.DeleteById(id);
        }

        public bool UpdateCheese(Cheese cheese)
        {
            return _cheeseRepository.UpdateById(cheese);
        }

        public void CreateCheese(Cheese cheese)
        {
            _cheeseRepository.Create(cheese);
        }
    }
}
