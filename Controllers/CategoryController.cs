using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] ApplicationDbContext database)
        {
            var categories = await database.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromServices] ApplicationDbContext database, [FromBody] Category model)
        {
            if (ModelState.IsValid) {
                database.Categories.Add(model);
                await database.SaveChangesAsync();
                return model;
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}