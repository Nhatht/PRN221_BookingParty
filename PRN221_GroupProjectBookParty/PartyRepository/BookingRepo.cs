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
        public void AddBooking(Booking booking) => BookingDAO.Instance.AddBooking(booking);

        public List<Booking> GetAllBooking() => BookingDAO.Instance.GetAllBooking();

        public List<Booking> GetBookingByAccountId(int id) => BookingDAO.Instance.GetBookingByAccountId(id);

        public Booking GetBookingById(int id) => BookingDAO.Instance.GetBookingById(id);

        public void UpdateBooking(Booking booking) => BookingDAO.Instance.UpdateBooking(booking);
        public List<Booking> GetBookingByHostId(int id) => BookingDAO.Instance.GetBookingByHostId(id);
    }
}
