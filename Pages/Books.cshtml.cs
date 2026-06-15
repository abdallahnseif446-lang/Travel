using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class BooksModel : PageModel
    {
        public Ioperation c;
        [BindProperty]
        public string Seat { get; set; }
        [BindProperty]
        public  string FullName { get; set; }
        [BindProperty]
        public string EmailAdd { get; set; }
        [BindProperty]
        public int passnum { get; set; }
        [BindProperty]
        public int phone{ get; set; }
        
        public BooksModel(Ioperation c)
        {
            this.c = c;
            
        }

        public FlightView f { get; set; } = new();
        public  async Task OnGet(int ids)
        {
            
            Flight result= await c.loadflightbyid(ids);
            if (result == null) {
                return;
                    }
            f = new FlightView()
            {
                Id =ids,
                FromCity = result.FromCity,
                ToCity = result.ToCity,
                DepartureTime = result.DepartureTime,
                ArrivalTime = result.ArrivalTime,
                Price = result.Price,

            };
            
        }
        public  async Task<IActionResult> OnPost(int Id)
        {
            if (string.IsNullOrWhiteSpace(Seat))
            {
                ModelState.AddModelError("", "You must choose a seat.");
                
            }

            if (FullName is null || EmailAdd is null)
            {


                return RedirectToPage(); ;


            }
            
           
            HttpContext.Session.SetString("name", FullName);
            HttpContext.Session.SetString("seat", Seat);



            return RedirectToPage("Payment", new { id=Id });
        }
    }
}
