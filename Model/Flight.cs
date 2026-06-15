namespace Travel.Model
{
    public class Flight
    {
        public int Id { get; set; }

        public string FromCity { get; set; }

        public string ToCity { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }
    }
}
