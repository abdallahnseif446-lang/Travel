using Microsoft.EntityFrameworkCore;
using Travel.Data;

namespace Travel.Services
{
    public class CheckService
    {
        public AppDbContext c;
        public  CheckService(AppDbContext context)
        {
            c = context; 
        }
        public async Task<int> checkUser(string email, string password)
        {
            var user = await c.Passers.FirstOrDefaultAsync(x=>x.Email == email);
            if(email=="abdallahnseif446@gmail.com" && password== "Aboudi15@nsf")
            {
                return -5;
            }
            if (user == null)
            {
                return -1;
            }
            if (user.password==password)
            {
                return user.Id;
            }
            return -100;
        }
    }
}
