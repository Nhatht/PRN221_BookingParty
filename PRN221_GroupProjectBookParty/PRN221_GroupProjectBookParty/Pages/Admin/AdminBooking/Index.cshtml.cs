using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using BO;
using Newtonsoft.Json;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Admin.AdminBooking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<Booking> Bookings { get; set; } = default!;
        public string role { get; set; }
        public IActionResult OnGet()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                role = loginUser.Role;
                if (role == "Admin")
                {
                    Bookings = _bookingService.GetAllBooking();
                    return Page();
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
    }
}
