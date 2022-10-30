using CheeseLover.Shared.Models;

namespace CheeseLover.Api.Infrastructure
{
    public class CheeseRepository : ICheeseRepository
    {
        private readonly ApiContext _dbContext;

        public CheeseRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Cheese cheese)
        {

            var lastId =  _dbContext.Cheeses.LastOrDefault()?.Id;
            cheese.Id = lastId.HasValue ? lastId.Value + 1: 0;

            _dbContext.Add(cheese);

            SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var cheeseToDelete = GetById(id);

            if(cheeseToDelete != null)
            {
                _dbContext.Remove(cheeseToDelete);
                SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Cheese> Get()
        {
            return _dbContext.Cheeses.ToList();
        }

        public Cheese GetById(int id)
        {
            return _dbContext.Cheeses.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool UpdateById(Cheese cheese)
        {
            var cheeseToUpdate = GetById(cheese.Id);

            if(cheeseToUpdate == null)
            {
                return false;
            }
            else
            {
                cheeseToUpdate.Name = cheese.Name;
                cheeseToUpdate.Category = cheese.Category;
                cheeseToUpdate.CheeseColor = cheese.CheeseColor;
                cheeseToUpdate.Price = cheese.Price;
                cheeseToUpdate.PictureUrl = cheese.PictureUrl;
                cheeseToUpdate.Description = cheese.Description;
                cheeseToUpdate.UpdatedAt = DateTime.Now;
            }

            _dbContext.Update(cheeseToUpdate);
            SaveChanges();

            return true;
        }
    }
}
