using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class ViewPassangersModel : PageModel
    {
        public Ioperation c;
        public ViewPassangersModel(Ioperation c)
        {
            this.c = c;
        }
        public int counter { get; set; }

        public List<Passanger> p { get; set; } = new List<Passanger>();
        public async  Task OnGet()
        {
            p = await c.loadusers();
            foreach(var user in p)
            {
                counter = counter + 1;

            }
            counter = counter;
        }
        public async Task<IActionResult> OnPost(int id)
        {
            await c.deleteusers(id);
            return RedirectToPage();
        }
    }
}
