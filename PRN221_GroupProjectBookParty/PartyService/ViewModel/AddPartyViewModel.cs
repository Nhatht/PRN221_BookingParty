using BO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService.ViewModel
{
    public class AddPartyViewModel
    {
        public AddPartyViewModel()
        {        
        }

        public int HostId { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Theme { get; set; }
        public string? Package { get; set; }
        public int MaxPeople { get; set; }
        public IFormFile? ImageUrl { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Account Host { get; set; } = null!;
    }
}
