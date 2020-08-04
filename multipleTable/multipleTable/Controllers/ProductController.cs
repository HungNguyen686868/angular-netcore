using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multipleTable.Data;
using multipleTable.Models;

namespace multipleTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MultipleTableDbContext _context;

        public ProductController(MultipleTableDbContext context)
        {
            _context = context;
        }

        [HttpGet] //Read
        public ActionResult<List<Product>> GetAll() =>
            _context.Products.ToList();

        [HttpGet("{id}")] // Read
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost] // Create
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")] //Update
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")] // Delete
        public async Task<IActionResult> Delete(int id) 
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //[HttpGet]
        //public List<Product> GetProdutByName(string searchString)
        //{
        //    var product = _context.Products.ToList();
        //    var response = new List<Product>();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        response = product.Where(x => x.Name.Contains(searchString)).ToList();
        //    }
        //    return response;
        //}

        ////[HttpGet]
        //public List<Product> GetProductByCategoryID()
        //{
        //    var query = from p in _context.Products
        //                join q in _context.Categories on p.CategoryId equals q.Id
        //                select new Product
        //                {
        //                    Id = p.Id,
        //                    Name = p.Name,
        //                    Price = p.Price,
        //                    OriginalPrice = p.OriginalPrice,
        //                    Stock = p.Stock,
        //                    ViewCount = p.ViewCount,
        //                    CategoryId = p.CategoryId,
        //                    DateCreated = p.DateCreated,
        //                    SeoAlias = p.SeoAlias
        //                };
        //    return query.ToList();
        //}

        //[HttpGet]
        //public List<Product> getproductbyprice(decimal pricenumber)
        //{
        //    var product = _context.Products.ToList();
        //    var response = new List<Product>();
        //    response = product.Where(x => x.Price > pricenumber).Where(y => y.Stock < 5).ToList();
        //    return response;
        //}
    }

}
