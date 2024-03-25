using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostParty
{
    public class DeleteModel : PageModel
    {
        private readonly IPartysService _partysService;

        public DeleteModel(IPartysService partysService)
        {
            _partysService = partysService;
        }

        [BindProperty]
      public Party Party { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _partysService.GetAllParties() == null)
            {
                return NotFound();
            }

            var party = await _partysService.GetPartyById(id);

            if (party == null)
            {
                return NotFound();
            }
            else 
            {
                Party = party;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _partysService.GetAllParties() == null)
            {
                return NotFound();
            }
            var party = await _partysService.GetPartyById(id);

            if (party != null)
            {
                Party = party;
                await _partysService.DeleteParty(id);
            }

            return RedirectToPage("./PartyManagement");
        }
    }
}
