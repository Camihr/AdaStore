using AdaStore.Shared.Data;
using AdaStore.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdaStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productos = await context.Products.ToListAsync();
            return Ok(productos);
        }
    }
}
