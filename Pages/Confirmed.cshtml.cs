using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class ConfirmedModel : PageModel
    {
        public Ioperation c;
        public ConfirmedModel(Ioperation c)
        {
            this.c = c;
        }
        public FlightView f { get; set; } = new();
        public string? name { get; set; }
        public int price { get; set; }
        public string s { get; set; }
        public async Task OnGet(int id)
        {
            
            price = HttpContext.Session.GetInt32("price") ?? 0;

            s = HttpContext.Session.GetString("seat");
            
            Flight res =  await c.loadflightbyid(id);
            if (res is null) {
                return;
            }
            f = new FlightView()
            {
                DepartureTime = res.DepartureTime,
                ArrivalTime = res.ArrivalTime,
                Price = res.Price, 
                FromCity = res.FromCity,
                ToCity = res.ToCity

            };
            var idd = HttpContext.Session.GetInt32("UserId") ?? 0;
            name = await c.loadname(idd);
            



        }
    }
}
