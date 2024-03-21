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

        public async Task OnGetAsync()
        {
            if (_partysService.GetAllParties() != null)
            {
                Party = _partysService.GetAllParties();
            }
        }
    }
}
