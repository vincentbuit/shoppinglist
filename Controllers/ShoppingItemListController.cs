using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemListController : ControllerBase
    {
        private readonly ShoppingItemListContext _context;

        public ShoppingItemListController(ShoppingItemListContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingItemList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingItemList>>> GetShoppingItemLists()
        {
            return await _context.ShoppingItemLists.ToListAsync();
        }

        // GET: api/ShoppingItemList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingItemList>> GetShoppingItemList(long id)
        {
            var shoppingItemList = await _context.ShoppingItemLists.FindAsync(id);

            if (shoppingItemList == null)
            {
                return NotFound();
            }

            return shoppingItemList;
        }

        // PUT: api/ShoppingItemList/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingItemList(long id, ShoppingItemList shoppingItemList)
        {
            if (id != shoppingItemList.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingItemList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingItemListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingItemList
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingItemList>> PostShoppingItemList(ShoppingItemList shoppingItemList)
        {
            _context.ShoppingItemLists.Add(shoppingItemList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShoppingItemList), new { id = shoppingItemList.Id }, shoppingItemList);
        }

        // DELETE: api/ShoppingItemList/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingItemList>> DeleteShoppingItemList(long id)
        {
            var shoppingItemList = await _context.ShoppingItemLists.FindAsync(id);
            if (shoppingItemList == null)
            {
                return NotFound();
            }

            _context.ShoppingItemLists.Remove(shoppingItemList);
            await _context.SaveChangesAsync();

            return shoppingItemList;
        }

        private bool ShoppingItemListExists(long id)
        {
            return _context.ShoppingItemLists.Any(e => e.Id == id);
        }
    }
}
