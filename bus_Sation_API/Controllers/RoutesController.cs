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

        [HttpPost("routes/{departureLocation}/{destination}/{departureTime}")]
        public ActionResult<BusRoute> AddRoute(string departureLocation, string destination, string departureTime)
        {
            BusRoute route = new BusRoute
            {
                DepartureLocation = departureLocation,
                Destination = destination,
                DepartureTime = departureTime
            };
            _context.BusRoutes.Add(route);
            _context.SaveChanges();
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

        [HttpPut("routes/{id}/{departureLocation}/{destination}/{departureTime}")]
        public IActionResult UpdateRoute(int id, string departureLocation, string destination, string departureTime)
        {
            BusRoute routeToUpdate = _context.BusRoutes.FirstOrDefault(r => r.Id == id);
            if (routeToUpdate == null)
            {
                return NotFound();
            }

            routeToUpdate.DepartureLocation = departureLocation;
            routeToUpdate.Destination = destination;
            routeToUpdate.DepartureTime = departureTime;

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete("routes/{id}")]
        public IActionResult DeleteRoute(int id)
        {
            BusRoute routeToDelete = _context.BusRoutes.FirstOrDefault(r => r.Id == id);
            if (routeToDelete == null)
            {
                return NotFound();
            }

            _context.BusRoutes.Remove(routeToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
