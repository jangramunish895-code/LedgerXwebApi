
using Application.Dtos;
using Application.Users;
using Domain;
using Infrastructure;
using Infrastructure.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        //[HttpGet]
        //public async Task<ActionResult<List<UserDto>>> GetUsers()
        //{
        //    try
        //    {
        //        var users = await _userApplication.GetAll();
        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"Internal server error: {ex.Message}");
        //    }
        //}




        //[HttpPost]
        //public async Task<ActionResult> AddUser(CreateUpdateUserDto userDto)
        //{
        //    try
        //    {
        //        await _userApplication.Add(userDto);
        //        return Ok();
        //    }


        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, "error");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    try
        //    {
        //      await _userApplication.Delete(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetUserById(int id)
        //{
        //    try
        //    {
        //       var user = await _userApplication.GetById(id);
        //        if(user == null)
        //        {
        //            return NotFound($"User with ID {id} not found.");
        //        }
        //        return Ok(user);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"Internal server error: {ex.Message}");
        //    }

        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateUser(int id, CreateUpdateUserDto input)
        //{
        //    try
        //    {
        //        var existingUser = await _userApplication.GetById(id);
        //        if (existingUser == null)
        //        {
        //            return NotFound($"User with ID {id} not found.");
        //        }
        //            await _userApplication.Update(id, input);
        //            return Ok(input);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"Internal server error: {ex.Message}");
        //    }
        //    }
        //}
    }

}
