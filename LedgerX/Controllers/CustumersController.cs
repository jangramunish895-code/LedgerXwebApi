using Application.Custumers;
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
        //private readonly DataContext _context;
        private readonly ICustumerApplication _custumerApplication;
        public CustumersController(ICustumerApplication custumerApplication)
        {
            _custumerApplication = custumerApplication;

        }

        [HttpGet]
        public async Task<ActionResult<List<CustumerDto>>> GetCustumers()
        {

            try
            {
                var custumers = await _custumerApplication.GetAll();
                return Ok(custumers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddCustumers(CreateUpdateCustomerDto custumers)
        {
            try
            {
                await _custumerApplication.Add(custumers);
                return Ok(custumers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustumers(int id, CreateUpdateCustomerDto custumers)
        {
            try
            {
                var existingCustumer = await _custumerApplication.GetById(id);
                if (existingCustumer == null)
                {
                    return NotFound($"Custumers with ID {id} not found.");
                }
                await _custumerApplication.Update(id, custumers);
                return Ok($"Custumers with ID {id} updated successfully.");

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
                await _custumerApplication.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }
    }

}