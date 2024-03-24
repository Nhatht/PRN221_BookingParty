using BO;
using BO.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PartyService;
using PartyService.ViewModel;
using PRN221_GroupProjectBookParty.Models;
using PRN221_WebNovel.Models;
using System.Collections.Generic;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostBooking
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<Booking> Booking { get; set; }
        private readonly IBookingService bookingService;
        public int HostId { get; set; }
        public string role { get; set; }
        public ListModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }
        public async Task<IActionResult> OnGet()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                HostId = loginUser.Id;
                role = loginUser.Role;
                if (role == "Host")
                {
                    Booking =  await bookingService.GetBookingByHostId(HostId);
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
        public async Task<IActionResult> OnPostConfirm(int id)
        {
            try
            {
                var bk = await bookingService.GetBookingById(id);
                bk.Status = "Approved";
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
                bk.Status = "Deny";
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
        public async Task<IActionResult> OnPostFinish(int id)
        {
            try
            {

                var bk = await bookingService.GetBookingById(id);
                if(DateTime.Now >= bk.StartDate)
                {
                    bk.Status = "Finish";
                    await bookingService.UpdateBooking(bk);
                    ViewData["Notification"] = new Notification
                    {
                        Message = "Record Updated Successfully !",
                        Type = NotificationType.Success
                    };
                }
                else
                {
                    TempData["ErrorFinish"] = "The StartDate haven't start yet";
                }
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage("/Host/HostBooking/List");
        }
    }
}
