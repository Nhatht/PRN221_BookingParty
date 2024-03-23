using BO;
using BO.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using PartyService.ViewModel;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostBooking
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<Booking> Booking { get; set; }
        private readonly IBookingService bookingService;
        public ListModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }
        public void OnGet()
        {
            Booking = bookingService.GetBookingByHostId(2);
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
