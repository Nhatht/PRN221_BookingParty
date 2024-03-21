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
        public SendFeedBackModel(IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public IActionResult OnGetAsync(int id)
        {
            //if (id == 5) return NotFound();
            id = 1;
            var booking = _feedbackService.GetBookingById(id);
			if (booking != null)
			{
				ViewData["GuestId"] = booking.GuestId;
                //ViewData["GuestName"] = booking.GuestName;
                ViewData["PartyId"] = booking.PartyId;
				return Page();
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
