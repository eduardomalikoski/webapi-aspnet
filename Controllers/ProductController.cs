using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] ApplicationDbContext database)
        {
            var products = await database.Products.Include(p => p.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] ApplicationDbContext database, int id)
        {
            var product = await database.Products.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] ApplicationDbContext database, int id)
        {
            var products = await database.Products.Include(p => p.Category).AsNoTracking().Where(p => p.Category.Id == id).ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] ApplicationDbContext database, [FromBody] Product model)
        {
            if (ModelState.IsValid) {
                database.Products.Add(model);
                await database.SaveChangesAsync();
                return model;
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}