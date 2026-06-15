using System.ComponentModel.DataAnnotations;

namespace Travel.Model
{
    public class FlightBinding
    {
        [Required(ErrorMessage ="Please enter your informations")]
        public string FromCity { get; set; }
        [Required]
        public string ToCity { get; set; }
        
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }
        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }
    }
}
