using bus_Sation_API.Data;
using bus_Sation_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bus_Sation_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController
    {
        private readonly ApplicationDBContext _context;

        public LogsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("logs")]
        public List<Logs> GetLogs()
        {
            return _context.Logs.ToList();
        }
    }
}
