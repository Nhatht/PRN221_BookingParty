using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Guest
{
    public class PartyUserModel : PageModel
    {
        private readonly IPartysService _partysService;

        public PartyUserModel(IPartysService partysService)
        {
            _partysService = partysService;
        }

        public IList<Party> Party { get; set; } = default!;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string ErrorMessage { get; set; } = "";
        public async Task<IActionResult> OnGetAsync(int currentPage = 1)
        {
            if (_partysService.GetAllParties() != null)
            {
                int pageSize = 5;
                Party = _partysService.GetAllParties();
                TotalPages = (int)Math.Ceiling(Party.Count / (double)pageSize);
                CurrentPage = Math.Min(Math.Max(currentPage, 1), TotalPages);
                Party = Party.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            return Page();
        }
    }
}
