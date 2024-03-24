using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using PRN221_GroupProjectBookParty.Models;
using Stripe.Checkout;

namespace PRN221_GroupProjectBookParty.Pages
{
    public class BookingConfirmationModel : PageModel
    {
        private readonly IBookingService bookingService;
        public int BookingId { get; set; }
        public BookingConfirmationModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }
        public async Task OnGet(int id)
        {
            var bk = await bookingService.GetBookingById(id);
            if(bk != null && BookingStatus.SessionId != null)
            {
                var service = new SessionService();
                Session session = service.Get(BookingStatus.SessionId);
                if(session.PaymentStatus.ToLower() == "paid")
                {
                    BookingStatus.Status = "Paid";
                    BookingStatus.IsActive = "Paid";
                }
            }
            BookingId = id;
        }
    }
}
