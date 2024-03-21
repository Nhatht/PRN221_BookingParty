using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
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
    

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountToDelete = _accountService.GetAccountById(id);

            if (accountToDelete == null)
            {
                return NotFound();
            }

            _accountService.DeleteAccount(accountToDelete);

                return RedirectToPage("./Index");

        }
    }
}
