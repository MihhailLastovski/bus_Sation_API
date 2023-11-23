namespace bus_Sation_API.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }

        public BusRoute() { }
        public BusRoute(string departureLocation, string destination, string departureTime)
        {
            DepartureLocation = departureLocation;
            Destination = destination;
            DepartureTime = departureTime;
        }
    }
}
