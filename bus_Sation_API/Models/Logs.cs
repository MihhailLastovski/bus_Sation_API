namespace bus_Sation_API.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
