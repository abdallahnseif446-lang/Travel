using Microsoft.EntityFrameworkCore;
using Travel.Data;
using Travel.Model;
using Travel.Services.Interfaces;

namespace Travel.Services
{
    public class operation : Ioperation
    {
        public AppDbContext db {  get; set; }
        public operation(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<int> addtodata(UserBindingModel u)
        {
            Passanger passanger = new Passanger();
            passanger.Email = u.EmailAddress;
            passanger.password=u.Password;
            passanger.PassportNumber= u.PassportNumber;
            passanger.FullName= u.FullName;
            await db.Passers.AddAsync(passanger);
            await db.SaveChangesAsync();
            return passanger.Id;
        }

        public async Task addflights(FlightBinding f)
        {
            try
            {

                Flight flight = new Flight()
                {
                    DepartureTime = f.DepartureTime,
                    ArrivalTime = f.ArrivalTime,
                    FromCity = f.FromCity,
                    ToCity = f.ToCity,
                    Price = f.Price,
                    TotalSeats = f.TotalSeats,
                    AvailableSeats = f.AvailableSeats
                };
                await db.Flights.AddAsync(flight);
                await db.SaveChangesAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public async Task<int> searchFlight(FlightBinding f)
        {
            var user = await db.Flights.FirstOrDefaultAsync(x => x.FromCity == f.FromCity);
            if (user == null)
            {
                return -1;

            }
            else if (user.ToCity == f.ToCity && user.DepartureTime.Day == f.DepartureTime.Day && user.DepartureTime.Year==f.DepartureTime.Year && user.DepartureTime.Month==f.DepartureTime.Month)
            {
                return user.Id;
            }else if (f.DepartureTime != user.DepartureTime)
            {
                return -2;
            }
            return 0;
        }

        public async Task<List<Flight>> viewflights(string FromCity, string ToCity)
        {
           return await db.Flights.Where(x=>x.FromCity==FromCity && x.ToCity==ToCity).ToListAsync();    

        }

        public async Task<Flight> loadflightbyid(int id)
        {
            var user=await db.Flights.FirstOrDefaultAsync(x=>x.Id==id);
            return user;
        }

        public async Task<int> bookingfrompassnger(int? id ,int flightid)
        {
            if (id is null)
            {
                return -2;
            }
            var pass= await db.Passers.FirstOrDefaultAsync(x=>x.Id==id);
            var f = await db.Flights.FirstOrDefaultAsync(x => x.Id == flightid);
            if (pass == null || f==null)
            {
                return -1;
            } else
            {
                var booking = new Booking
                {
                    PassengerId = (int)id,
                    Passenger=pass,
                    FlightId = flightid,
                    Status = "Pending",
                    Flight = f
                };
                await db.Bookings.AddAsync(booking);
                await db.SaveChangesAsync();
                return booking.Id;

            }
        }

        public async Task<int> pays(int id, int amount)
        {
            Payment pay = new Payment()
            {
                BookingId = id,
                Amount = amount
            };
            await db.Payment.AddAsync(pay);
            await db.SaveChangesAsync();
            return pay.Id;
        }

        public async Task<List<Booking>> loadbooking()
        {
            return await db.Bookings.Include(r=>r.Passenger)
                .Include(r=>r.Flight).ToListAsync();

            
        }

        public async Task<string> loadname(int id)
        {
            var name = await db.Passers.FirstOrDefaultAsync(x => x.Id == id);
            return name.FullName;
        }



        public async Task<int> changebooktoyes(int id)
        {
            var book = await db.Bookings
                .Include(x => x.Flight)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
                return -1;

            book.Status = "Confirmed";

            if (book.Flight == null)
                return -2;

            book.Flight.AvailableSeats--;

            if (book.Flight.AvailableSeats <= 0)
            {
                db.Bookings.Remove(book);
                db.Flights.Remove(book.Flight);
            }

            await db.SaveChangesAsync();
            return 1;
        }

        public async Task<int> changebooktono(int id)
        {
            var book = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return -1;
            }


            book.Status = "Cancelled";
            
            await db.SaveChangesAsync();
            return 0;
        }

        public async Task<List<Passanger>> loadusers()
        {
            return await db.Passers.ToListAsync();
        }

        public async  Task<int> deleteusers(int id)
        {
            var user = await  db.Passers.FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
            {
               return -1;
            }
          
             db.Passers.Remove(user);
            await db.SaveChangesAsync();
            return 1;

        }

        public async Task<List<Flight>> loadflights()
        {
            return await db.Flights.ToListAsync();
        }

        public async Task<List<Payment>> loadpays()
        {
            
            return await db.Payment.ToListAsync();
        }
    }
}
