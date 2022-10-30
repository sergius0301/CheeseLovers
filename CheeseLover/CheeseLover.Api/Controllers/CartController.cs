using CheeseLover.Api.Services;
using CheeseLover.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheeseLover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok(_cartService.CreateCart());
        }

        [HttpPost("add")]
        public IActionResult AddCart([FromBody] CartItemVM cartItem)
        {
            _cartService.AddToCart(cartItem);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cheese = _cartService.GetCartById(id);

            return cheese == null ? NotFound() : Ok(cheese);
        }
    }
}
