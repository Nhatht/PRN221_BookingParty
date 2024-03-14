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

namespace PRN221_GroupProjectBookParty.Pages.Host.HostParty
{
    public class EditModel : PageModel
    {
        private readonly IPartysService _partysService;

        public EditModel(IPartysService partysService)
        {
            _partysService = partysService;
        }

        [BindProperty]
        public Party Party { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var party = await _partysService.GetPartyById(id);
                if(party == null) return NotFound();
                //var partyVM = new EditPartyViewModel
                //{
                //    Description = party.Description,
                //    Name = party.Name,
                //    City = party.City,
                //    Price = party.Price,
                //    Theme = party.Theme,
                //    Package = party.Package,
                //    MaxPeople = party.MaxPeople,
                //    Url = party.ImageUrl,
                //    Status = party.Status,
                //};

                Party = party;
                var host = _partysService.GetAllHost();
                ViewData["HostId"] = new SelectList(host, "Id", "UserName");
            }
            catch (Exception ex)
            {
                 
            }
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _partysService.;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(Party.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartyExists(int id)
        {
          return (_partysService.GetAllParties().Any(e => e.Id == id));
        }
    }
}
