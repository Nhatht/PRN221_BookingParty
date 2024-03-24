using BO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string? Description { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        [Range(0, 999999, ErrorMessage = "Price must be a positive number and not more than 7 digits.")]
        public decimal Price { get; set; }
        [Required]
        public string? Theme { get; set; }
        [Required]
        public string? Package { get; set; }
        [Required]
        [Range(0, 5000)]
        public int MaxPeople { get; set; }
        [Required]
        public IFormFile? ImageUrl { get; set; } = null!;
        public bool Status { get; set; }

    }
}
