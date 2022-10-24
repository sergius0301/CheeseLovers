using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Infrastructure
{
    public interface ICheeseRepository
    {
        public List<Cheese> Get();
        public Cheese GetById(int id);
        public bool DeleteById(int id);
        public bool UpdateById(Cheese cheese);
        public void Create(Cheese cheese);
        public void SaveChanges();
    }
}
