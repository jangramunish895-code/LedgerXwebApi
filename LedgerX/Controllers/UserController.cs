
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
        //private readonly DataContext _context;
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateUpdateUserDto input)
        {
            await _userApplication.Add(input);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            var users = await _userApplication.GetAll();
                        return Ok(users);



           

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userApplication.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userApplication.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
        return Ok();
        }
       
    }

}
