using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class IndexModel : PageModel


    {
        private readonly Ioperation c;
        [BindProperty]
        public FlightBinding f { get; set; } = new();
        public FlightView view { get; set; } = new FlightView();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, Ioperation c)
        {
            _logger = logger;
            this.c = c;
        }

        public IActionResult OnGet(int y)
        {
            if(y!=0)
            {
                return Page();
            }
            else
            {

            return RedirectToPage("/Login");
            }

        }
        public async Task<IActionResult> OnPost()
        {
            int flag = await c.searchFlight(f);
            if (f.DepartureTime == DateTime.MinValue)
            {
                return RedirectToPage("bookall", new { FromCity = f.FromCity, ToCity = f.ToCity });
            }

            if (flag == -1)
            {
                ModelState.AddModelError("f.FromCity", "No Flights From your City");

               
            }else if(flag== -2)
            {
                ModelState.AddModelError("f.DepartureTime", "No flights in this date");
            }
           
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            return RedirectToPage("Books", new { ids = flag });



        }
    }
}
