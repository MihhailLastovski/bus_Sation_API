using bus_Sation_API.Data;
using bus_Sation_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace bus_Sation_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("register/{username}/{password}/{role}")]
        public IActionResult Register(string username, string password, string role)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return Conflict(new { message = "User already exists" });
            }

            User newUser = new User
            {
                Username = username,
                Password = HashPassword(password),
                Role = role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            string hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword)
            {
                return Unauthorized(new { message = "Invalid password" });
            }

            return Ok(new { message = "Logged in successfully", role = user.Role });
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}