using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductsController(MyDBContext context)
        {
            _context = context;
        }


        // GET: Products
        [HttpGet(Name = "GetListProduct")]
        public async Task<IActionResult> Index()
        {
            ;
            return Ok(await _context.Products.ToListAsync());

        }

        // GET: Products/Details/5
        [HttpGet(Name = "GetListProduct/Detail/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
                //  return Json("notfound");
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }



        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return Ok(product);
        }


        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPut]
        public async Task<IActionResult> Edit(Product product)
        {
            // if (id != product.Id)
            // {
            //    return NotFound(product);
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                  //  if (!ProductExists(product.Id))
                  //  {
                   //     return NotFound(product);
                   // }
                   // else
                   // {
                   //     throw;
                   // }
                }

            }
            return Ok(product);
        }

        // GET: Products/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //    if (id == null || _context.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        // }

        //[Route("{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

       // [NonAction]
       // private bool ProductExists(int id)
       // {
        //  return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
       // }
    }
}
