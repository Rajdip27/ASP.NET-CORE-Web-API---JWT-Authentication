using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWT_Authentication.DatabaseContext;
using JWT_Authentication.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTtOKEN.Controllers
{
    [Authorize]
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomer>>> GettblCustomers()
        {
            return await _context.tblCustomers.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomer>> GetTblCustomer(int id)
        {
            var tblCustomer = await _context.tblCustomers.FindAsync(id);

            if (tblCustomer == null)
            {
                return NotFound();
            }

            return tblCustomer;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, TblCustomer tblCustomer)
        {
            if (id != tblCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<TblCustomer>> CustomerAdd(TblCustomer tblCustomer)
        {
            _context.tblCustomers.Add(tblCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomer", new { id = tblCustomer.Id }, tblCustomer);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var tblCustomer = await _context.tblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            _context.tblCustomers.Remove(tblCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerExists(int id)
        {
            return _context.tblCustomers.Any(e => e.Id == id);
        }
    }
}
