using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class AdminModel : PageModel
    {
        public Ioperation c;
        public AdminModel(Ioperation c)
        {
            this.c = c;
        }
        public List<Booking> b { get; set; } = new List<Booking>();
        public List<Passanger> p { get; set; } = new();
        public List<Flight> f { get; set; } = new();
        public List<Payment> pay { get; set; } = new();
        public int counter { get; set; }
        public int counterp { get; set; }
        public int counterf {get; set; }
        public int prices { get; set; }
        public async Task OnGet()
        {
            var k= HttpContext.Session.GetInt32("adminid");
            if (k is null)
            {
                RedirectToPage("/Login");
            }
            b = await c.loadbooking();
            p = await c.loadusers();
            f = await c.loadflights();
            pay = await c.loadpays();

            foreach (var book in b)
            {
                counter = counter + 1;

            }
            counter = counter;

            foreach (var user in p)
            {
                counterp = counterp + 1;

            }
            counterp = counterp;
            foreach (var flight in f)
            {
                counterf = counterf + 1;

            }
            counterf = counterf;

            foreach (var book in b)
            {
                foreach (var a in pay)
                {
                    if (book.Id == a.BookingId)
                    {
                        if (book.Status == "Confirmed")
                        {
                            prices += (int)a.Amount;
                        }

                    }
                       
                }
               
                 
                
            }
            prices = prices;
            
            
        }
        
    }
}
