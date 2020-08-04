using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multipleTable.Data;
using multipleTable.Models;

namespace multipleTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MultipleTableDbContext _context;

        public CategoryController(MultipleTableDbContext context)
        {
            _context = context;
        }

        [HttpGet] //Read
        public ActionResult<List<Category>> GetAll() =>
            Ok(_context.Categories.ToList());

        [HttpGet("{id}")] // Read
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var product = await _context.Categories.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost] // Create
        public async Task<IActionResult> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")] //Update
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")] // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
