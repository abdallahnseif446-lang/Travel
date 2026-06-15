using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class AddFlightsModel : PageModel
    {
        public Ioperation c;
        public AddFlightsModel(Ioperation c)
        {
            this.c = c;
        }
        [BindProperty]
        public FlightBinding f { get; set; } = new();

        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
                return Page();

            }
            await  c.addflights(f);
            return RedirectToPage("AddFlights");
        }
    }
}
