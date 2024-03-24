using BO;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PartyService;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostBooking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public IList<Booking> Bookings { get; set; }
        public int HostId { get; set; }
        public string role { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                HostId = loginUser.Id;
                role = loginUser.Role;
                if (role == "Host")
                {
                    Bookings = await _bookingService.GetBookingByHostId(HostId);
                    return Page();
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be a host to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be a host to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
    }
}
