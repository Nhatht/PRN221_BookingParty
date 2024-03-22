using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyRepository;
using PartyService;
using PRN221_GroupProjectBookParty.Models.ViewModels;

namespace PRN221_GroupProjectBookParty.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Account checkLogin = _accountService.GetAccountByEmail(Account.Email);
            if (checkLogin != null)
            {
                bool isMatch = PasswordHasher.VerifyPassword(Account.Email, checkLogin.Password);
                if (isMatch)
                {
                    if (checkLogin.Role.Equals("Admin")) { return RedirectToPage("/Admin/AdminAccount/Index"); }
                    else if (checkLogin.Role.Equals("Host")) { return RedirectToPage("/Teacher_page/Index"); }
                    else if (checkLogin.Role.Equals("Guest")) { return RedirectToPage("/Student_page/Index"); }
                }
            }
            return Page();
        }
    }
}
