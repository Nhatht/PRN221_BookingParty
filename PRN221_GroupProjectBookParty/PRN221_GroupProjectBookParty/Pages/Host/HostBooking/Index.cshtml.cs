using BO;
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

        public async Task OnGetAsync()
        {
            if(HttpContext.Session.GetString("loginUser") != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(HttpContext.Session.GetString("loginUser"));
                HostId = loginUser.Id;
                Bookings = _bookingService.GetBookingByHostId(HostId);
            }else
            {
                RedirectToPage("/Authentication/Login");
            }
        }
    }
}
