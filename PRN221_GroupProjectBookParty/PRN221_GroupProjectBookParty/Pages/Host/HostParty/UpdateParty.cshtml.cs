using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BO;
using PartyService;
using PartyService.ViewModel;
using PartyService.PhotoUpload;

namespace PRN221_GroupProjectBookParty.Pages.Host.HostParty
{
    public class EditModel : PageModel
    {
        private readonly IPartysService _partysService;
        private readonly IPhotoService _photoService;

        public EditModel(IPartysService partysService, IPhotoService photoService)
        {
            _partysService = partysService;
            _photoService = photoService;
        }

        [BindProperty]
        public EditPartyViewModel Party { get; set; } = default!;
        [BindProperty]
        public bool Status { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var party = _partysService.GetPartyByIdNoAsync(id);
            if (party == null) return NotFound();
            Party = new EditPartyViewModel
            {
                Description = party.Description,
                Name = party.Name,
                City = party.City,
                Price = party.Price,
                Theme = party.Theme,
                Package = party.Package,
                MaxPeople = party.MaxPeople,
                Url = party.ImageUrl,
                Status = party.Status,
            };

            Party = Party;
            var host = _partysService.GetAllHost();
            ViewData["HostId"] = new SelectList(host, "Id", "UserName");

            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var party = await _partysService.GetPartyByIdNoTracking(id);
            if (Party.Price <= 0 || Party.Price.ToString().Length > 6)
            {
                ModelState.AddModelError("Party.Price", "Price should be greater than 0 and have a length equal to or less than 7.");
                return Page();
            }
            else if (Party.MaxPeople > 5000)
            {
                ModelState.AddModelError("Party.MaxPeople", "Max People should not exceed 500.");
                return Page();
            }
            if (party != null)
            {
                var partyVM = new Party();
                if (Party.ImageUrl != null)
                {
                    await _photoService.DeletePhotoAsync(party.ImageUrl);
                    var photoResult = await _photoService.AddPhotoAsync(Party.ImageUrl);
                    partyVM.Id = id;
                    partyVM.Description = Party.Description;
                    partyVM.Name = Party.Name;
                    partyVM.City = Party.City;
                    partyVM.Price = Party.Price;
                    partyVM.Theme = Party.Theme;
                    partyVM.Package = Party.Package;
                    partyVM.MaxPeople = Party.MaxPeople;
                    partyVM.ImageUrl = photoResult.Url.ToString();
                    partyVM.Status = Party.Status;
                }
                else
                {
                    partyVM.Id = id;
                    partyVM.Description = Party.Description;
                    partyVM.Name = Party.Name;
                    partyVM.City = Party.City;
                    partyVM.Price = Party.Price;
                    partyVM.Theme = Party.Theme;
                    partyVM.Package = Party.Package;
                    partyVM.MaxPeople = Party.MaxPeople;
                    partyVM.ImageUrl = party.ImageUrl;
                    partyVM.Status = Party.Status;
                }
                await _partysService.UpdateParty(partyVM);
                return RedirectToPage("./PartyManagement");
            }


            return Page();
        }

        private bool PartyExists(int id)
        {
            return (_partysService.GetAllParties().Any(e => e.Id == id));
        }
    }
}
