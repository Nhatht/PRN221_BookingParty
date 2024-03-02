using PartyRepository;

namespace PartyService;

public class BookingService : IBookingService
{
    private IBookingRepo _bookingRepo;

    public BookingService()
    {
        _bookingRepo = new BookingRepo();
    }
}