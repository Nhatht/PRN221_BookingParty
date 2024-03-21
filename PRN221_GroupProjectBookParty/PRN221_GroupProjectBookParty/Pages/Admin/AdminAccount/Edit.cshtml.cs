using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var account = _accountService.GetAccountById(id);
            if (id == null || account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var account = _accountService.GetAccountById(id);
            if(id == null || account == null)
            {
                return NotFound();
            }
            account.Email= Account.Email;
            account.Password= Account.Password;
            account.UserName= Account.UserName;
            account.Phone= Account.Phone;
            account.Gender = Account.Gender;
            account.Role= Account.Role;
            _accountService.UpdateAccount(account);
            return RedirectToPage("./Index");
        }

    }
}
