using CheeseLover.Api.Infrastructure;
using CheeseLover.Shared.Enums;
using CheeseLover.Shared.Models;
using Shouldly;

namespace CheeseLover.API.Tests
{
    [TestClass]
    public class CheeseRepositoryTests
    {

        private readonly CheeseRepository _repo;

        public CheeseRepositoryTests()
        {
            _repo = new CheeseRepository(new ApiContext());
        }

        [TestMethod]
        public void CreateCheese_WillAddCheese()
        {
            //Arrange  

            var cheese = new Cheese
            {
                Id = 1,
                Category = CheeseType.SemiSoft,
                CheeseColor = CheeseColor.Yellow,
                Price = 12,
                Name = "Gouda",
                Description = "Some good cheese",
                PictureUrl = "http://google.com"
            };
            //Act 

            _repo.Create(cheese);

            //Assert

            var createdCheese = _repo.GetById(1);

            createdCheese.CheeseColor.ShouldBe(cheese.CheeseColor);
            createdCheese.Category.ShouldBe(cheese.Category);
            createdCheese.Price.ShouldBe(cheese.Price);
            createdCheese.PictureUrl.ShouldBe(cheese.PictureUrl);
            createdCheese.Name.ShouldBe(cheese.Name);
        }
    }
}
