using Travel.Model;

namespace Travel.Services.Interfaces
{
    public interface Ioperation
    {
        public Task<int> addtodata(UserBindingModel u);
        public Task<int> searchFlight(FlightBinding f);
        public Task addflights(FlightBinding f);
        public Task<List<Flight>> viewflights(string FromCity,string ToCity);
        public Task<Flight> loadflightbyid(int id);
        public Task<int> bookingfrompassnger(int? id,int flightid);
        public Task<int> pays(int id,int amount);
        public Task<List<Booking>> loadbooking();
        public Task<string> loadname(int id);
        public Task<int> changebooktoyes(int id);
        public Task<int> changebooktono(int id);
        public Task<List<Passanger>> loadusers();
        public Task<int> deleteusers(int id);
        public Task<List<Flight>> loadflights();
        public Task<List<Payment>> loadpays();

    }
}
