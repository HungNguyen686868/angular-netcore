//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using multipleTable.Data;
//using multipleTable.Models;

//namespace multipleTable.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartController : ControllerBase
//    {
//        private readonly MultipleTableDbContext _context;

//        public CartController(MultipleTableDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet] //Read
//        public ActionResult<List<Cart>> GetAll() =>
//            _context.Carts.ToList();

//        [HttpGet("{id}")] // Read
//        public async Task<ActionResult<Cart>> GetById(int id)
//        {
//            var cart = await _context.Carts.FindAsync(id);

//            if (cart == null)
//            {
//                return NotFound();
//            }

//            return cart;
//        }

//        [HttpPost] // Create
//        public async Task<IActionResult> Create(Cart cart)
//        {
//            _context.Carts.Add(cart);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetById), new { id = cart.Id }, cart);
//        }

//        [HttpPut("{id}")] //Update
//        public async Task<IActionResult> Update(int id, Cart cart)
//        {
//            if (id != cart.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpDelete("{id}")] // Delete
//        public async Task<IActionResult> Delete(int id)
//        {
//            var cart = await _context.Carts.FindAsync(id);

//            if (cart == null)
//            {
//                return NotFound();
//            }

//            _context.Carts.Remove(cart);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }
//}
