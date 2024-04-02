using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical1App.Data;
using Practical1App.Models;

namespace Practical1App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeExperienceDetailsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeExperienceDetailsController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeExperienceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeExperienceDetails>>> GetEmployeeExperienceDetails()
        {
          if (_context.EmployeeExperienceDetails == null)
          {
              return NotFound();
          }
            return await _context.EmployeeExperienceDetails.ToListAsync();
        }

        // GET: api/EmployeeExperienceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeExperienceDetails>> GetEmployeeExperienceDetails(int id)
        {
          if (_context.EmployeeExperienceDetails == null)
          {
              return NotFound();
          }
            var employeeExperienceDetails = await _context.EmployeeExperienceDetails.FindAsync(id);

            if (employeeExperienceDetails == null)
            {
                return NotFound();
            }

            return employeeExperienceDetails;
        }

        // PUT: api/EmployeeExperienceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeExperienceDetails(int id, EmployeeExperienceDetails employeeExperienceDetails)
        {
            if (id != employeeExperienceDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeExperienceDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExperienceDetailsExists(id))
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

        // POST: api/EmployeeExperienceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeExperienceDetails>> PostEmployeeExperienceDetails(EmployeeExperienceDetails employeeExperienceDetails)
        {
          if (_context.EmployeeExperienceDetails == null)
          {
              return Problem("Entity set 'EmployeeDbContext.EmployeeExperienceDetails'  is null.");
          }
            _context.EmployeeExperienceDetails.Add(employeeExperienceDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeExperienceDetails", new { id = employeeExperienceDetails.Id }, employeeExperienceDetails);
        }

        // DELETE: api/EmployeeExperienceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeExperienceDetails(int id)
        {
            if (_context.EmployeeExperienceDetails == null)
            {
                return NotFound();
            }
            var employeeExperienceDetails = await _context.EmployeeExperienceDetails.FindAsync(id);
            if (employeeExperienceDetails == null)
            {
                return NotFound();
            }

            _context.EmployeeExperienceDetails.Remove(employeeExperienceDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExperienceDetailsExists(int id)
        {
            return (_context.EmployeeExperienceDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
