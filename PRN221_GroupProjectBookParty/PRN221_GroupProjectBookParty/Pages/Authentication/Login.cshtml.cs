using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PartyRepository;
using PartyService;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public string ErrorMessage { get; set; }  = "";
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("loginUser") != null)
            {
                return RedirectToPage("/Reader/Index");
            }
            return Page();
        }
        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!string.IsNullOrEmpty(Account.Email) && !string.IsNullOrEmpty(Account.Password))
            {
                var account = _accountService.Login(Account.Email, Account.Password);
                if (account == null)
                {
                    TempData["ErrorMessage"] = "Email or Password is incorrect";
                    return Page();
                }
                else
                {
                    var loginUser = new AccountViewmodel
                    {
                        Id = Account.Id,
                        UserName = Account.UserName,
                        Role = Account.Role
                    };
                    var loginUserJson = JsonConvert.SerializeObject(loginUser);
                    HttpContext.Session.SetString("loginUser", loginUserJson);
                    var role = Account.Role;
                    if (role == "Admin")
                    {
                        return RedirectToPage("/Admin/AdminAccount");
                    }
                    else if (role == "Host")
                    {
                        return RedirectToPage("/Host/HostParty/PartyManagement");
                    }
                    else if (role == "Guest")
                    {
                        return RedirectToPage("/Guest/PartyView");
                    }
                    else
                    {
                        ErrorMessage = "Invalid email or password";
                        return Page();
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid ID or Password";
                return Page();
            }
            return Page();
        }
    }
}
