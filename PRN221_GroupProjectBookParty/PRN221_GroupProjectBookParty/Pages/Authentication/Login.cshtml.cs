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
        [BindProperty]
        public Account Account { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("loginUser") != null)
            {
                return RedirectToPage("/Guest/PartyView");
            }
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if(!string.IsNullOrEmpty(Account.Email) && !string.IsNullOrEmpty(Account.Password))
            {
                var account = _accountService.GetAccountByEmail(Account.Email);
                bool passwordMatch = PasswordHashing.VerifyPassword(Account.Password, account.Password);
                if (account == null)
                {
                    TempData["ErrorMessage"] = "Email or Password is incorrect";
                    return Page();
                }
                else
                {
                    if(account.Status == false)
                    {
                        TempData["ErrorMessage"] = "Your account has been blocked";
                        return Page();
                    }
                    var loginUser = new AccountViewmodel
                    {
                        Id = account.Id,
                        UserName = account.UserName,
                        Role = account.Role
                    };
                    var loginUserJson = JsonConvert.SerializeObject(loginUser);
                    HttpContext.Session.SetString("loginUser", loginUserJson);
                    var role = account.Role;
                    if (role == "Admin")
                    {
                        return RedirectToPage("/Admin/AdminAccount/Index");
                    }
                    else if (role == "Host")
                    {
                        return RedirectToPage("/Host/HostParty/PartyManagement");
                    }
                    else if (role == "User")
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
        }
    }
}
