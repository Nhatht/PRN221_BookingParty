using BO;
using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class BookingService : IBookingService
    {
        private IBookingRepo _bookingRepo = null;
        public BookingService()
        {
            _bookingRepo = new BookingRepo();
        }

        public void AddBooking(Booking booking) => _bookingRepo.AddBooking(booking);

        public List<Booking> GetAllBooking() => _bookingRepo.GetAllBooking();

        public List<Booking> GetBookingByAccountId(int id) => _bookingRepo.GetBookingByAccountId(id);

        public Booking GetBookingById(int id) => _bookingRepo.GetBookingById(id);

        public void UpdateBooking(Booking booking) => _bookingRepo.UpdateBooking(booking);
        public List<Booking> GetBookingByHostId(int id) => _bookingRepo.GetBookingByHostId(id);
    }
}
