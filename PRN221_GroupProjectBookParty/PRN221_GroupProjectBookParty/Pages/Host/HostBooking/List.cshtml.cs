using BO;
using BO.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PartyService;
using PartyService.ViewModel;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostBooking
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<Booking> Booking { get; set; }
        private readonly IBookingService bookingService;
        public int HostId { get; set; }
        public ListModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("loginUser") != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(HttpContext.Session.GetString("loginUser"));
                HostId = loginUser.Id;
                Booking = bookingService.GetBookingByHostId(HostId);
            }
            else
            {
                RedirectToPage("/Authentication/Login");
            }
        }
        public async Task<IActionResult> OnPostConfirm(int id)
        {
            try
            {
                var bk = await bookingService.GetBookingById(id);
                bk.Status = true;
                await bookingService.UpdateBooking(bk);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCancel(int id)
        {
            try
            {
                var bk = await bookingService.GetBookingById(id);
                bk.Status = false;
                await bookingService.UpdateBooking(bk);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }
    }
}
