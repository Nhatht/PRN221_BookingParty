using BO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Guest
{
    public class PartyDetailModel : PageModel
    {
        private readonly IPartysService _partysService;

        public PartyDetailModel(IPartysService partysService)
        {
            _partysService = partysService;
        }

        public Party Party { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {            
            Party = await _partysService.GetPartyById(id);
        }
    }
}
