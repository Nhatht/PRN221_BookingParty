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
    }
}
