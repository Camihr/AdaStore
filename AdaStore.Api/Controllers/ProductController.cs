using AdaStore.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productos = new List<Product>()
            {
                new Product { Id = 1, Name = "TV"},
                new Product { Id = 2, Name = "PC"},
                new Product { Id = 3, Name = "RF"},
            };

            return Ok(productos);
        }
    }
}
