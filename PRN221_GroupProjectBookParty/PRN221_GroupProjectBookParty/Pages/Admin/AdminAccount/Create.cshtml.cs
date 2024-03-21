using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Accounts { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var account = _accountService.GetAccountByEmail(Accounts.Email);
            if(account != null)
            {
                TempData["EmailMessage"] = "Email exist!";
                return Page();
            }
            Accounts.Status = true;
            _accountService.AddAccount(Accounts);

            return RedirectToPage("./Index");
        }
    }
}
