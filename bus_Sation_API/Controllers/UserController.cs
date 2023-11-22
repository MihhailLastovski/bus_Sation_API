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

        [HttpPost("register")]
        public IActionResult Register(User userData)
        {
            if (_context.Users.Any(u => u.Username == userData.Username))
            {
                return Conflict(new { message = "User already exists" });
            }

            User newUser = new User
            {
                Username = userData.Username,
                Password = HashPassword(userData.Password),
                Role = userData.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok(newUser.Id);
        }

        [HttpPost("login")]
        public IActionResult Login(User loginData)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == loginData.Username);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            string hashedPassword = HashPassword(loginData.Password);
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