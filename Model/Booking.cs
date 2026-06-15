namespace Travel.Model
{
    public class Booking
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public Passanger? Passenger { get; set; }

        public int FlightId { get; set; }

        public Flight Flight { get; set; }

       

        public string Status { get; set; }
    }
}
