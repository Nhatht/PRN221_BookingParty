using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [BindProperty]
        public Account Account { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }


        public IActionResult OnPost()
        {

            if (_accountService.GetAccountByEmail(Account.Email) != null)
            {

                return RedirectToPage("/Authentication/Login");
            }

            Account newAccount = new Account();
            newAccount.Status = true;
            newAccount.Email = Account.Email;
            newAccount.Password = Account.Password;
            newAccount.UserName = Account.UserName;
            newAccount.Phone = Account.Phone;
            newAccount.Gender = Account.Gender;
            newAccount.Role = "Guest";
             _accountService.AddAccount(newAccount);

            return RedirectToPage("/Authentication/Login");
        }
    }
}
