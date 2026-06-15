using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using Travel.Model;
using Travel.Services;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class AddBookingModel : PageModel
    {
        public Ioperation c;
        public AddBookingModel(Ioperation c)
        {
            this.c = c;
           
        }

        public List<Booking> b { get; set; } = new();
        public int conf {  get; set; }
        public int can { get; set; }
        public string s { get; set; }
        public async Task OnGet()
        {
            b = await c.loadbooking();

            s = HttpContext.Session.GetString("seat");

            foreach (var booking in b)
            {
                if (booking.Status == "Confirmed")
                {
                    conf = conf + 1;

                }
                if (booking.Status == "Cancelled")
                {
                    can = can + 1;

                }

            }
            conf = conf;
            can = can;
        }
        public async Task<IActionResult> OnPostConfirm(int id)
        {
             await c.changebooktoyes(id);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostCancel(int id)
        {
            await c.changebooktono(id);
            return RedirectToPage();
        }

    }
}
