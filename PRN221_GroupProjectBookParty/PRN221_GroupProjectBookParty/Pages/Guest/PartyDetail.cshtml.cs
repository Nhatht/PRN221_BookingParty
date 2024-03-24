using BO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Guest
{
    public class PartyDetailModel : PageModel
    {
        private readonly IPartysService _partysService;
		private readonly IFeedBackService _feedBackService;
		private readonly IAccountService _accountService;

		public PartyDetailModel(IPartysService partysService, IFeedBackService feedBackService, IAccountService accountService)
		{
			_partysService = partysService;
			_feedBackService = feedBackService;
			_accountService = accountService;
		}

		public Party Party { get; set; } = default!;
		public List<FeedBack> FeedBack { get; set; } = default!;
		public Dictionary<int, string> GuestName { get; set; } = new Dictionary<int, string>();
		public async Task OnGetAsync(int id)
        {            
            Party = await _partysService.GetPartyById(id);
			FeedBack = _feedBackService.GetFeedBackByPartyId(id);
			var feedBacks = _feedBackService.GetFeedBackByPartyId(id);
			foreach (var feedback in feedBacks)
			{
				if (!GuestName.ContainsKey(feedback.GuestId))
				{
					var account = _accountService.GetAccountById(feedback.GuestId);
					GuestName.Add(feedback.GuestId, account.UserName);
				}
			}
		}
    }
}
