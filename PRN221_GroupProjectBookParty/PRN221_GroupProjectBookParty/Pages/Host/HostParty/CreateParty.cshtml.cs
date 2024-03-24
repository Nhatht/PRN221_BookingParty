using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO;
using PartyService;
using PartyService.ViewModel;
using PartyService.PhotoUpload;
using System.IO;
using Newtonsoft.Json;
using PRN221_WebNovel.Models;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostParty
{
    public class CreateModel : PageModel
    {
        private readonly IPartysService _partysService;
        private readonly IPhotoService _photoService;

        public CreateModel(IPartysService partysService, IPhotoService photoService)
        {
            _partysService = partysService;
            _photoService = photoService;
        }

        public IActionResult OnGet()
        {
            var host = _partysService.GetAllHost();
            ViewData["HostId"] = new SelectList(host, "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public AddPartyViewModel Party { get; set; } = default!;
        public string StatusMessage { get; set; }
        public int HostId { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var loginUserJson = HttpContext.Session.GetString("loginUser");

            var loginUser = JsonConvert.DeserializeObject<AccountViewmodel>(loginUserJson);
            HostId = loginUser.Id;
            var result = await _photoService.AddPhotoAsync(Party.ImageUrl);
            if (result != null)
            {
                var party = new Party
                {
                    HostId = HostId,
                    Description = Party.Description,
                    Name = Party.Name,
                    City = Party.City,
                    Price = Party.Price,
                    Theme = Party.Theme,
                    Package = Party.Package,
                    MaxPeople = Party.MaxPeople,
                    ImageUrl = result.Url.ToString(),
                    Status = Party.Status,
                };
                bool addsuccessfully = await _partysService.AddParty(party);
                if (addsuccessfully)
                {

                    return RedirectToPage("./PartyManagement");
                }
                else
                {
                    return RedirectToPage("./Index");
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
