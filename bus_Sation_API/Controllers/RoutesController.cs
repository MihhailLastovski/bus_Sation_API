using bus_Sation_API.Data;
using bus_Sation_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bus_Sation_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RoutesController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("routes")]
        public List<BusRoute> GetRoutes()
        {
            return _context.BusRoutes.ToList();
        }

        [HttpPost("routes/{departureLocation}/{destination}/{departureTime}/{username}/{destinationTime}/{busCompany}/{tickets}")]
        public ActionResult<BusRoute> AddRoute(string departureLocation, string destination, string departureTime, string username, string destinationTime, string busCompany, int tickets)
        {
            BusRoute route = new BusRoute
            {
                DepartureLocation = departureLocation,
                Destination = destination,
                DepartureTime = departureTime,
                DestinationTime = destinationTime,
                BusCompany = busCompany,
                TicketsCount = tickets
            };
            _context.BusRoutes.Add(route);
            _context.SaveChanges();
            LogAction($"AddRoute: {route.Id} Id", username); 
            return CreatedAtAction(nameof(GetRouteById), new { id = route.Id }, route);
        }

        [HttpGet("routes/{id}")]
        public ActionResult<BusRoute> GetRouteById(int id)
        {
            BusRoute route = _context.BusRoutes.FirstOrDefault(r => r.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        [HttpPut("routes/{id}/{departureLocation}/{destination}/{departureTime}/{username}/{destinationTime}/{busCompany}/{tickets}")]
        public IActionResult UpdateRoute(int id, string departureLocation, string destination, string departureTime, string username, string destinationTime, string busCompany, int tickets)
        {
            BusRoute routeToUpdate = _context.BusRoutes.FirstOrDefault(r => r.Id == id);
            if (routeToUpdate == null)
            {
                return NotFound();
            }

            routeToUpdate.DepartureLocation = departureLocation;
            routeToUpdate.Destination = destination;
            routeToUpdate.DepartureTime = departureTime;
            routeToUpdate.DestinationTime = destinationTime;
            routeToUpdate.BusCompany = busCompany;
            routeToUpdate.TicketsCount = tickets;

            _context.SaveChanges();
            LogAction($"UpdateRoute: {routeToUpdate.Id} Id", username); 
            return Ok();
        }

        [HttpDelete("routes/{id}/{username}")]
        public IActionResult DeleteRoute(int id, string username)
        {
            BusRoute routeToDelete = _context.BusRoutes.FirstOrDefault(r => r.Id == id);
            if (routeToDelete == null)
            {
                return NotFound();
            }

            _context.BusRoutes.Remove(routeToDelete);
            _context.SaveChanges();
            LogAction($"DeleteRoute: {routeToDelete.Id} Id", username); 
            return Ok();
        }

        private void LogAction(string action, string username)
        {
            Logs log = new Logs
            {
                Action = action,
                Username = username,
                Timestamp = DateTime.Now
            };
            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
