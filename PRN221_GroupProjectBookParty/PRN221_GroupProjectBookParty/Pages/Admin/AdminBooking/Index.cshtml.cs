using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using BO;

namespace PRN221_GroupProjectBookParty.Pages.Admin.AdminBooking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<Booking> Bookings { get; set; } =default!;
        public void OnGet()
        {
            Bookings = _bookingService.GetAllBooking();
        }
    }
}
