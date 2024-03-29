using BO;
using BO.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PartyService;
using PartyService.ViewModel;
using PRN221_WebNovel.Models;

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
        public string role { get; set; }
        public IActionResult OnGet()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                role = loginUser.Role;
                if (role == "Admin")
                {
                    Parties = _partyService.GetAllParties();
                    return Page();
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
        public async Task<IActionResult> OnPostConfirm(int id)
        {
            try
            {
                var bk = await _partyService.GetPartyById(id);
                bk.Status = true;
                await _partyService.UpdateParty(bk);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCancel(int id)
        {
            try
            {
                var bk = await _partyService.GetPartyById(id);
                bk.Status = false;
                await _partyService.UpdateParty(bk);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return RedirectToPage();
        }
    }
}
