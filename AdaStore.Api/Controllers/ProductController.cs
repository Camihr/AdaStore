﻿using AdaStore.Shared.Data;
using AdaStore.Shared.Enums;
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

        [HttpPost]
        public async Task<IActionResult> CreateProduct( [FromBody] Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            product.CreatedAt = DateTime.UtcNow;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            var existingProduct = await context.Products.FindAsync(product.Id);

            if (existingProduct == null)
                return BadRequest("El producto solicitado no existe");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Stock = product.Stock;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeeteProduct([FromQuery] int productId)
        {
            var product = await context.Products.FindAsync(productId);

            if (product == null)
                return BadRequest("El producto solicitado no existe");
          
            product.IsDeleted = true;
            product.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
