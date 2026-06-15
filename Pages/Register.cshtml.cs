using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Ioperation o;

        public RegisterModel(Ioperation operation)
        {
            o = operation;
        }

        [BindProperty]
        public UserBindingModel b { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var id = await o.addtodata(b);

         

            return RedirectToPage("/Index");
        }
    }
}