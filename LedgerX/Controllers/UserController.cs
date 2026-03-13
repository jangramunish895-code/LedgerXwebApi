
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
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            try
            {
                var users = await _context.Users.Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    City = u.City,
                    Country = u.Country,
                    Role = u.Role
                }).ToListAsync();
                return Ok(users);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateUpdateUserDto>> AddUser(CreateUpdateUserDto userDto)
        {
            try
            {
             var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    PhoneNumber = userDto.PhoneNumber,
                    Address1 = userDto.Address1,
                    Address2 = userDto.Address2,
                    City = userDto.City,
                    State = userDto.State,
                    Country = userDto.Country,
                    PinCode = userDto.PinCode
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
                }
            catch (Exception ex)
            {
                return StatusCode(400, "error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User with ");
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok("User with ID");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User with ID");
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User updatedUser)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User with ID");
                }
                user.FirstName = updatedUser.FirstName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.PhoneNumber = updatedUser.PhoneNumber;
                user.Address1 = updatedUser.Address1;
                user.Address2 = updatedUser.Address2;
                user.City = updatedUser.City;
                user.State = updatedUser.State;
                user.Country = updatedUser.Country;
                user.PinCode = updatedUser.PinCode;

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }
        }
    }
}
