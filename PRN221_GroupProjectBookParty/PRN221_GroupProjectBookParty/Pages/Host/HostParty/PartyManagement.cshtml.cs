using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostParty
{
    public class IndexModel : PageModel
    {
        private readonly IPartysService _partysService;

        public IndexModel(IPartysService partysService)
        {
            _partysService = partysService;
        }

        public IList<Party> Party { get;set; } = default!;
        public string Action { get; set; }
        public string StatusMessage { get; set; }
        public string role { get; set; }   
        public int HostId { get; set; } 
        public IActionResult OnGetAsync()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");
            if (loginUserJson != null)
            {
                var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
                HostId = loginUser.Id;
                role = loginUser.Role;
                if (role == "Host")
                {
                    Party = _partysService.GetPartyByHostId(HostId);
                    return Page();
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "You must be a host to perform this action.";
                    return RedirectToPage("/Authentication/Login");
                }
            }
            TempData["ErrorMessage"] = "You must be a host to perform this action.";
            return RedirectToPage("/Authentication/Login");
        }
    }
}
