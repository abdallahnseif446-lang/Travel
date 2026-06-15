namespace Travel.Model
{
    public class Passanger
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }
        public string? password { get; set; }
        public string? PassportNumber { get; set; }

        public List<Booking> Bookings { get; set; } = new();
    }
}
