using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProjectBookParty.Models.ViewModels;

namespace PRN221_GroupProjectBookParty.Pages;

public class ViewProfile : PageModel
{
    private readonly BookingPartyContext _bookingPartyContext;

    public ViewProfile(BookingPartyContext bookingPartyContext)
    {
        _bookingPartyContext = bookingPartyContext;
    }

    [BindProperty] public ChangePasswordViewModel ChangePasswordRequest { get; set; }

    public Account Account { get; set; }
    public IEnumerable<Booking> Bookings { get; set; }

    public IActionResult OnGet(int id)
    {
        Account = _bookingPartyContext.Accounts.Find(id);

        if (Account == null) return NotFound();
        
        Bookings = _bookingPartyContext.Bookings.Where(b => b.GuestId == id).ToList();
        
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        Account = _bookingPartyContext.Accounts.Find(id);

        if (Account == null)
            return NotFound();
        
        if (Account.Password != ChangePasswordRequest.OldPassword)
        {
          
            ModelState.AddModelError("ChangePasswordRequest.OldPassword", "Old password is incorrect.");
            return Page();
        }
        
        if (ChangePasswordRequest.NewPassword != ChangePasswordRequest.ConfirmPassword)
        {
            ModelState.AddModelError("ChangePasswordRequest.ConfirmPassword",
                "New password and Confirm password do not match.");
            return Page();
        }
        
        Account.Password = ChangePasswordRequest.NewPassword;
        _bookingPartyContext.SaveChanges();
        foreach (var key in ModelState.Keys.ToList())
        {
            ModelState.Remove(key);
        }
        TempData["SuccessMessage"] = "Password changed successfully.";
        return RedirectToPage("/ViewProfile", new { id });
    }
}