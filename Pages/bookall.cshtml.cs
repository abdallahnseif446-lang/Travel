using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class bookallModel : PageModel
    {
        public Ioperation operation;
        public List<FlightView> f { get; set; } = new();
        public String from { get; set; }
        public String To { get; set; }
        public int Counter { get; set; } = 0;

        public bookallModel(Ioperation operation)
        {
            this.operation = operation;
        }
        public async Task OnGet(string FromCity, string ToCity)
        {

            from = FromCity;
            To=ToCity;
            List<Flight> res = await operation.viewflights(FromCity, ToCity);
            if (res == null)
            {
                return;
            }
            foreach (var x in res)
            {
                f.Add(new FlightView()
                { Id=x.Id,ArrivalTime = x.ArrivalTime, DepartureTime = x.DepartureTime, FromCity = x.FromCity, ToCity = x.ToCity, Price=x.Price });
            }
            Counter = res.Count();
        }
          
        }
    }

