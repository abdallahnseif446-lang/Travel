using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly Ioperation c;

        public PaymentModel(Ioperation c)
        {
            this.c = c;
        }

        public FlightView f { get; set; } = new();

        [BindProperty]
        public string names { get; set; }

        public int x { get; set; }

        
        public int flightId { get; set; }

        
        public async Task<IActionResult> OnGet(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Register");

            names = HttpContext.Session.GetString("name");

            var flight = await c.loadflightbyid(id);

            if (flight == null)
                return RedirectToPage("/Index");

            f = new FlightView
            {
                Id = flight.Id,
                FromCity = flight.FromCity,
                ToCity = flight.ToCity,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Price = flight.Price
            };

            flightId = id;
            x = (int)flight.Price + 25;
           

            return Page();
        }

        public async Task<IActionResult> OnPost(int y ,int id)
        {
            Console.WriteLine("y=" + y + "id=" + id);
            var userId = HttpContext.Session.GetInt32("UserId");


            if (userId == null)
                return RedirectToPage("/Register");

            if (id <= 0)
                return RedirectToPage("/Index");

            var bookingId = await c.bookingfrompassnger(userId, id);

            if (bookingId <= 0)
                return RedirectToPage("/Index");
            HttpContext.Session.SetInt32("price",y) ;
            int? z = HttpContext.Session.GetInt32("price");
            Console.WriteLine(z);

            await c.pays(bookingId, y);

            return RedirectToPage("Confirmed", new { id = id });
        }
    }
}