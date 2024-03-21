using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Admin.AdminParty
{
    public class IndexModel : PageModel
    {
        private readonly IPartysService _partyService;

        public IndexModel(IPartysService partyService)
        {
            _partyService = partyService;
        }

        public IList<Party> Parties { get; set; } = new List<Party>();

        public void OnGet()
        {
            Parties = _partyService.GetAllParties();
        }
    }
}
