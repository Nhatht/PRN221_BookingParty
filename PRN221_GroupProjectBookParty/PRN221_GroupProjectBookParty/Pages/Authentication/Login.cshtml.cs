﻿using BO;
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
            if (ModelState.IsValid)
            {
                // Kiểm tra đăng nhập sử dụng dữ liệu từ Account model
                if (_accountService.Login(Account.Email, Account.Password))
                {
                    TempData["Email"] = Account.Email;
                    var account = _accountService.GetAccountByEmail(Account.Email);
                    if (account.Role.Equals("Admin")) { return RedirectToPage("/Admin/Index"); }
                    else if (account.Role.Equals("Host")) { return RedirectToPage("/Teacher_page/Index"); }
                    else if (account.Role.Equals("Guest")) { return RedirectToPage("/Student_page/Index"); }
                    
                }
                else
                {
                    // Đăng nhập thất bại, thêm lỗi vào ModelState
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }
            }

            // ModelState không hợp lệ, trả về trang hiện tại
            return Page();
        }
    }
}
