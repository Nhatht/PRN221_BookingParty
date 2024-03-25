using BO;
using BO.enums;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PartyService;
using PartyService.ViewModel;
using PRN221_WebNovel.Models;


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
        public int HostId { get; set; }
        public string role { get; set; }
        public BookingModel(IPartysService _partyService, IBookingService _bookingService)
        {
            partysService = _partyService;
            bookingService = _bookingService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetString("loginUser") != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(HttpContext.Session.GetString("loginUser"));
                HostId = loginUser.Id;
                Party = await partysService.GetPartyById(id);
                return Page();
            }
            else
            {
                return RedirectToPage("/Authentication/Login");
            }


        }
        public async Task<IActionResult> OnPost()
        {

            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                HostId = loginUser.Id;
                role = loginUser.Role;
                if (role == "User")
                {
                    if (AddBooking.NumberOfPeople > Party.MaxPeople)
                    {
                        ModelState.AddModelError("AddBooking.NumberOfPeople", "Number of people cannot exceed maximum allowed.");
                        return Page();
                    }
                    if (AddBooking.NumberOfPeople < 1)
                    {
                        ModelState.AddModelError("AddBooking.NumberOfPeople", "Number of people must be more than 1.");
                        return Page();
                    }

                    if (AddBooking.StartDate < DateTime.Now)
                    {
                        ModelState.AddModelError("AddBooking.StartDate", "Start date cannot be in the past.");
                        return Page();
                    }
                    var bk = new Booking()
                    {
                        PartyId = Party.Id,
                        GuestId = HostId,
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
                    TempData["Notification"] = JsonConvert.SerializeObject(noti);
                    return RedirectToPage("./PartyView");
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be a user to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be a user to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
    }
}

