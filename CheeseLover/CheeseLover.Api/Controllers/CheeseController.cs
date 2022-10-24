using CheeseLover.Api.Services;
using CheeseLover.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheeseLover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private readonly ICheeseService _cheeseService;

        public CheeseController(ICheeseService cheeseService)
        {
            _cheeseService = cheeseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cheeseService.GetAll());
        }

        // GET api/<CheeseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cheese = _cheeseService.GetCheeseById(id);

            return cheese == null ? NotFound() : Ok(cheese);
        }

        // POST api/<CheeseController>
        [HttpPost]
        public IActionResult Post([FromBody] Cheese cheese)
        {
            _cheeseService.CreateCheese(cheese);
            return Ok();
        }

        // PUT api/<CheeseController>/5
        [HttpPut]
        public IActionResult Put([FromBody]Cheese cheese)
        {
            var isUpdated = _cheeseService.UpdateCheese(cheese);

            return isUpdated ? Ok() : NotFound();
        }

        // DELETE api/<CheeseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isRemoved = _cheeseService.DeleteCheeseById(id);

            return isRemoved ? Ok() : NotFound();
        }
    }
}
