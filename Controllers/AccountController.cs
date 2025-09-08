using library.Entity;
using library.Interfaces.Services;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IConfiguration _configuration;

        public AccountController(IPeopleService peopleService, IConfiguration configuration)
        {
            _peopleService = peopleService;
            _configuration = configuration;
        }

        // Регистрация нового пользователя
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest model)
        {
            People? existingUser = _peopleService
                .GetAllPeople()
                .FirstOrDefault(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase));

            if (existingUser != null)
            {
                return BadRequest("Пользователь с таким email уже существует.");
            }

            var newUser = new People
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                Password = model.Password,
                RoleId = model.RoleId
            };

            _peopleService.AddPeople(newUser);
            return Ok("Пользователь успешно зарегистрирован.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            People? user = _peopleService
                .GetAllPeople()
                .FirstOrDefault(u =>
                    u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) &&
                    u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized("Неверный логин или пароль.");
            }

            string token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        // Генерация JWT
        private string GenerateJwtToken(People user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? "reader")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
