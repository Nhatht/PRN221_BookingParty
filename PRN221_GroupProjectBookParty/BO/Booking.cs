using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int PartyId { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        [Range(1,100, ErrorMessage = "Number of people must be greater than zero.")]
        public int NumberOfPeople { get; set; }
        public string? Inquiry { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public string Status { get; set; } = null!;

        public virtual Account Guest { get; set; } = null!;
        public virtual Party Party { get; set; } = null!;
    }
}
