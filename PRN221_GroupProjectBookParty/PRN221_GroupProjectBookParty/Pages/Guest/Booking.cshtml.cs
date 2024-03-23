using BO;
using BO.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using PartyService.ViewModel;
using System.Text.Json;

namespace PRN221_GroupProjectBookParty.Pages.Guest
{
    public class BookingModel : PageModel
    {
        [BindProperty]
        public Party Party { get; set; }
        [BindProperty]
        public AddBookingModel AddBooking { get; set; }
        private readonly IPartysService partysService;
        private readonly IBookingService bookingService;
        public BookingModel(IPartysService _partyService, IBookingService _bookingService)
        {
            partysService = _partyService;
            bookingService = _bookingService;
        }
        public async Task OnGet(int id)
        {
            Party = await partysService.GetPartyById(id);
            
        }
        public async Task<IActionResult> OnPost()
        {

            var bk = new Booking()
            {
                PartyId = Party.Id,
                GuestId = 2,
                NumberOfPeople = AddBooking.NumberOfPeople,
                TotalPrice = Party.Price,
                Inquiry = AddBooking.Inquiry,
                StartDate = AddBooking.StartDate
            };
            await bookingService.AddBooking(bk);

            var noti = new Notification
            {
                Type = NotificationType.Success,
                Message = "Booking Successfully ! Please Wait For Host Accept"
            };
            TempData["Notification"] = JsonSerializer.Serialize(noti);
            return RedirectToPage("./PartyView");
        }
    }
}

