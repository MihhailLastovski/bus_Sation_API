namespace bus_Sation_API.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string DestinationTime { get; set; }
        public string BusCompany { get; set; }
        public int TicketsCount { get; set; }

        public BusRoute() { }
        public BusRoute(string departureLocation, string destination, string departureTime, string destinationTime, string busCompany, int ticketsCount)
        {
            DepartureLocation = departureLocation;
            Destination = destination;
            DepartureTime = departureTime;
            DestinationTime = destinationTime;
            BusCompany = busCompany;
            TicketsCount=ticketsCount;
        }
    }
}
