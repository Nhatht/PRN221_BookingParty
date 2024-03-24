using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public class BookingRepo : IBookingRepo
    {
        public async Task AddBooking(Booking booking) => await BookingDAO.Instance.AddBooking(booking);

        public List<Booking> GetAllBooking() => BookingDAO.Instance.GetAllBooking();

        public List<Booking> GetBookingByAccountId(int id) => BookingDAO.Instance.GetBookingByAccountId(id);

        public async Task<Booking> GetBookingById(int id) => await BookingDAO.Instance.GetBookingById(id);

        public async Task UpdateBooking(Booking booking) => await BookingDAO.Instance.UpdateBooking(booking);
        public List<Booking> GetBookingByHostId(int id) => BookingDAO.Instance.GetBookingByHostId(id);
        public List<Booking> GetBookingByUserId(int id) => BookingDAO.Instance.GetBookingByUserId(id);
    }
}
