using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using PartyService;
using PartyService.PhotoUpload;
using PartyService.ViewModel;

namespace PRN221_GroupProjectBookParty.Pages.Guest
{
	public class SendFeedBackModel : PageModel
	{
		private readonly IFeedBackService _feedbackService;
		private readonly IBookingService _bookingService;
		private readonly IPartysService _partysService;
		private readonly IAccountService _accountService;
		public SendFeedBackModel(IFeedBackService feedbackService, IBookingService bookingService, IPartysService partysService, IAccountService accountService)
		{
			_feedbackService = feedbackService;
			_bookingService = bookingService;
			_partysService = partysService;
			_accountService = accountService;
		}
		public IActionResult OnGetAsync(int id)
		{
			id = 1;
			var booking = _bookingService.GetBookingById(id);
			if (booking != null)
			{
				ViewData["GuestId"] = booking.Result.GuestId;
				ViewData["PartyId"] = booking.Result.PartyId;
			}
			var party = _partysService.GetPartyById(booking.Result.PartyId);
			if (party != null)
			{
				ViewData["PartyName"] = party.Result.Name;
			}
			var acc = _accountService.GetAccountById(booking.Result.GuestId);
			if (acc != null)
			{
				ViewData["GuestName"] = acc.UserName;
			}
			return Page();
		}
		[BindProperty]
		public FeedBack FeedBack { get; set; }
		public async Task<IActionResult> OnPostAsync(int id)
		{
			var feedback = new FeedBack
			{
				Id = FeedBack.Id,
				GuestId = FeedBack.GuestId,
				PartyId = FeedBack.PartyId,
				Comment = FeedBack.Comment,
				ReviewDate = FeedBack.ReviewDate,
			};
			_feedbackService.CreateFeedBack(feedback);
			return RedirectToPage("./Index");
		}
	}
}
