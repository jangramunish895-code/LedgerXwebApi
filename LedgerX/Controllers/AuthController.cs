using Application.Email;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IEmailService _emailService;
        public AuthController(IConfiguration configuration, DataContext context, IEmailService emailService)
        {
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _emailService.SendEmail("jangramunish895@gmail.com", "Get", "Get Successfully");
            return Ok(new { Message = "Success" });
        }


        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var exists = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (exists == null)
            {
                return BadRequest("User not exists");
            }

            int otpCode = OtpGenerate();

            var otp = new Otp
            {
                UserId = exists.Id,
                Code = otpCode,
                CreateDate = DateTime.UtcNow,
            };

            await _context.Otps.AddAsync(otp);
            await _context.SaveChangesAsync();

            string subject = "Password Reset";
            string body = $"Your Otp code is {otpCode}.";

            await _emailService.SendEmail(email, subject, body);

            return Ok("Reset email sent");
        }



        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(int code)
        {
            var otp = await _context.Otps.FirstOrDefaultAsync(x => x.Code == code);

            if (otp == null)
            {
                return BadRequest("Otp code not found");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == otp.UserId);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            string token = GenerateToken(user.Email);

            return Ok(token);
        }


        [Authorize]
        [HttpPost("change-password")]
        public  async Task <IActionResult > ChangePassword(string oldPassword,string newPassword)
        {
            var email = User.FindFirst("username");
         
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email.Value);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            if(user.Password != oldPassword)
            {
                return BadRequest("Old password is incorrect");
            }
            user.Password = newPassword;
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok("Password changed");
        }
        
        [HttpPost("login")]
        public IActionResult Login(string username,string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == username && x.Password == password);
            if (user != null)
            {
                var token = GenerateToken(username);
                
                return Ok(new { Token = token  ,Message="Success"});
            }
            return BadRequest("Username or password is incorrect");
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ResetPass(string newPassword)
        {
            var email = User.FindFirst("username");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email.Value);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            user.Password = newPassword;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Password changed");
        }



        private string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("role","Admin"),

                new Claim("username", username),
              
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],

                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            var JwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return JwtToken;
        }

        private int OtpGenerate()
        {
            var random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
