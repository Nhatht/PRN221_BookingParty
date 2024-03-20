using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyRepository;
using PartyService;

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

            // Kiểm tra đăng nhập sử dụng dữ liệu từ Account model
            if (_accountService.Login(Account.Email, Account.Password))
            {
                TempData["Email"] = Account.Email;
                var account = _accountService.GetAccountByEmail(Account.Email);
                if (account.Status == true)
                {
                    if (account.Role.Equals("Admin")) { return RedirectToPage("/Admin/Index"); }
                    else if (account.Role.Equals("Host")) { return RedirectToPage("/Host/HostParty/PartyManagement"); }
                    else if (account.Role.Equals("Guest")) { return RedirectToPage("/Guest_page/Index"); }
                }
            }
            else
            {
                return Page();
            }



            // ModelState không hợp lệ, trả về trang hiện tại
            return Page();
        }
    }
}
