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
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                Account = _accountService.GetListAccount()
                    .Where(a => a.Gender.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                a.Email.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                a.Role.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                a.UserName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Account = _accountService.GetListAccount();
            }
        }
    }
}
