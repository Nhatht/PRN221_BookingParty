using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public interface IBookingRepo
    {
        List<Booking> GetAllBooking();
        Task<Booking> GetBookingById(int id);
        List<Booking> GetBookingByAccountId(int id);
        Task AddBooking(Booking booking);
        Task UpdateBooking(Booking booking);
         Task<List<Booking>> GetBookingByHostId(int id);
        List<Booking> GetBookingByUserId(int id);
        public List<Booking> GetPayment();
        public List<BookingRevenue> GetRevenueHost(int year);
    }
}
