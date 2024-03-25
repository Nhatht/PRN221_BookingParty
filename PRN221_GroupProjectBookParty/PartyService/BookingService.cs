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

        public async Task AddBooking(Booking booking) => await _bookingRepo.AddBooking(booking);

        public List<Booking> GetAllBooking() => _bookingRepo.GetAllBooking();

        public List<Booking> GetBookingByAccountId(int id) => _bookingRepo.GetBookingByAccountId(id);

        public async Task<Booking> GetBookingById(int id) => await _bookingRepo.GetBookingById(id);

        public async Task UpdateBooking(Booking booking) => await _bookingRepo.UpdateBooking(booking);
        public List<Booking> GetBookingByHostId(int id) => _bookingRepo.GetBookingByHostId(id);
        public List<Booking> GetBookingByUserId(int id) => _bookingRepo.GetBookingByUserId(id);
        public List<Booking> GetPayment() => _bookingRepo.GetPayment();
        public List<BookingRevenue> GetRevenueHost(int year) => _bookingRepo.GetRevenueHost(year);
    }
}
