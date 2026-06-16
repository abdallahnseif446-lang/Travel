using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Travel.Model;
using Travel.Services;

namespace Travel.Pages
{

    public class LoginModel : PageModel
    {
        [BindProperty]
        public loginbinding user { get; set; }
        public CheckService c { get; set; }
        public LoginModel(CheckService c) { this.c = c; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            int flag= await c.checkUser(user.EmailAddress,user.Password);
           

             if (flag == -1)
            {
                ModelState.AddModelError("user.EmailAddress", "you must register");
                return Page();

            }
            else if (flag == -5)
            {
                HttpContext.Session.SetInt32("adminid", 200);
                return RedirectToPage("/Admin");
            }else if(flag==-100){
                ModelState.AddModelError("user.Password", "incorrect password");

            }

            if (!ModelState.IsValid) { return Page(); }
            
            HttpContext.Session.SetInt32("UserId", flag);
            
            return RedirectToPage("Index", new {y=1});
        }
    }
}
