using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using PRN221_GroupProjectBookParty.Models.ViewModels;

namespace PRN221_GroupProjectBookParty.Pages;

public class ViewProfile : PageModel
{
    private readonly IAccountService _accountService;
    private readonly IBookingService _bookingService;
    private readonly BookingPartyContext _bookingPartyContext;

    public ViewProfile(IAccountService accountService, IBookingService bookingService, BookingPartyContext bookingPartyContext)
    {
        _accountService = accountService;
        _bookingService = bookingService;
        _bookingPartyContext = bookingPartyContext;
    }

    [BindProperty] public ChangePasswordViewModel ChangePasswordRequest { get; set; }

    [BindProperty] public Account Account { get; set; }
    public IEnumerable<Booking> Bookings { get; set; }

    public void OnGet(int id)
    {
        Account = _accountService.GetAccountById(id);
        Bookings = _bookingService.GetBookingByAccountId(id);
    }

    //public IActionResult OnPost(int id)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return RedirectToPage(new { id });
    //    }

    //    _accountService.UpdateAccount(Account);
    //    TempData["SuccessMessage"] = "Profile updated successfully.";
    //    return RedirectToPage(new { id });
    //}

    public IActionResult OnPost(int id)
    {
        

        Account.Password = ChangePasswordRequest.NewPassword;
        foreach (var key in ModelState.Keys.ToList())
        {
            ModelState.Remove(key);
        }
        TempData["SuccessMessage"] = "Password changed successfully.";
        return RedirectToPage(new { id });
    }
}