using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PartyService;
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
    }
}
