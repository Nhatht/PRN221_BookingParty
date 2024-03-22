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
        Booking GetBookingById(int id);
        List<Booking> GetBookingByAccountId(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        List<Booking> GetBookingByHostId(int id);
    }
}
