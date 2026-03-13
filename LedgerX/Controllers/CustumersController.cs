using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustumersController : ControllerBase
    {
        private readonly DataContext _context;
        public CustumersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<CustumerDto>> GetCustumers()
        {
            try
            {
                var custumers = await _context.Custumers.ToListAsync();
                var custumerDtos = custumers.Select(c => new CustumerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Notes = c.Notes,
                    Balance = c.Balance,
                    ProfilePicURL = c.ProfilePicURL
                }).ToList();
                return Ok(custumerDtos);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult<CreateUpdateCustomerDto>> AddCustumers(CreateUpdateCustomerDto custumers)
        {
            try
            {
                var newCustomer = new Custumers
                {
                    Name = custumers.Name,
                    Email = custumers.Email,
                    PhoneNumber = custumers.PhoneNumber,
                    Notes = custumers.Notes,
                    Balance = custumers.Balance,
                    ProfilePicURL = custumers.ProfilePicURL
                };
                
                _context.Custumers.Add(newCustomer);
                await _context.SaveChangesAsync();
                
                var custumerDto = new CreateUpdateCustomerDto
                {
                    Name = custumers.Name,
                    Email = custumers.Email,
                    PhoneNumber = custumers.PhoneNumber,
                    Notes = custumers.Notes,
                    Balance = custumers.Balance,
                    ProfilePicURL = custumers.ProfilePicURL
                };
                return Ok(custumerDto);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");

            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateUpdateCustomerDto>> UpdateCustumers(int id, Custumers custumers)
        {
            try
            {
                var existingCustumers = await _context.Custumers.FindAsync(id);
                if (existingCustumers == null)
                {
                    return NotFound($"Custumers with ID {id} not found.");
                }
                existingCustumers.Name = custumers.Name;
                existingCustumers.Email = custumers.Email;
                existingCustumers.PhoneNumber = custumers.PhoneNumber;
                existingCustumers.Notes = custumers.Notes;
                existingCustumers.Balance = custumers.Balance;
                existingCustumers.ProfilePicURL = custumers.ProfilePicURL;
                await _context.SaveChangesAsync();
                var custumerDto = new CreateUpdateCustomerDto
                {
                    Name = existingCustumers.Name,
                    Email = existingCustumers.Email,
                    PhoneNumber = existingCustumers.PhoneNumber,
                    Notes = existingCustumers.Notes,
                    Balance = existingCustumers.Balance,
                    ProfilePicURL = existingCustumers.ProfilePicURL
                };
                return Ok(custumerDto);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustumers(int id)
        {
            try
            {
                var custumers = await _context.Custumers.FindAsync(id);
                if (custumers == null)
                {
                    return NotFound($"Custumers with ID {id} not found.");
                }
                _context.Custumers.Remove(custumers);
                await _context.SaveChangesAsync();
                return Ok($"Custumers with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }
    }
}
