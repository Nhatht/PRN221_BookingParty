using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;
using PRN221_GroupProjectBookParty.Models;
using PRN221_GroupProjectBookParty.Models.ViewModels;
using Stripe;
using Stripe.Checkout;

namespace PRN221_GroupProjectBookParty.Pages;

public class ViewProfile : PageModel
{
    private readonly IBookingService bookingService;
    private readonly IAccountService accountService;

    public ViewProfile(IBookingService _bookingService, IAccountService accountService)
    {
        bookingService = _bookingService;
        this.accountService = accountService;
    }

    [BindProperty] public ChangePasswordViewModel ChangePasswordRequest { get; set; }

    public BO.Account Account { get; set; }
    public IEnumerable<Booking> Bookings { get; set; }

    public IActionResult OnGet(int id)
    {
        Account = accountService.GetAccountById(id);

        if (Account == null) return NotFound();
        
        Bookings = bookingService.GetBookingByUserId(id);
        
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        Account = accountService.GetAccountById(id);

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
        accountService.UpdateAccount(Account);
        foreach (var key in ModelState.Keys.ToList())
        {
            ModelState.Remove(key);
        }
        TempData["SuccessMessage"] = "Password changed successfully.";
        return RedirectToPage("/ViewProfile", new { id });
    }

    public async Task<IActionResult> OnPostPay(int id)
    {
        var bk = await bookingService.GetBookingById(id);
        var domain = "https://localhost:7254/";
        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)bk.TotalPrice * 100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Booking Party",
                            Description = "Total Distinct Item - " + 1
                        }
                    },
                    Quantity = 1
                },
            },
            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            Mode = "payment",
            SuccessUrl = domain + $"BookingConfirmation?id={bk.Id}",
            CancelUrl = domain + "Guest/PartyView",
        };
        var service = new SessionService();
        Session session = service.Create(options);
        BookingStatus.SessionId = session.Id;
        Response.Headers.Add("Location", session.Url);
        return new StatusCodeResult(303);
    }
}