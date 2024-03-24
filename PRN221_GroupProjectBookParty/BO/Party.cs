using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public partial class Party
    {
        public Party()
        {
            Bookings = new HashSet<Booking>();
            FeedBacks = new HashSet<FeedBack>();
        }

        public int Id { get; set; }
        public int HostId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        [Range(0, 9999999, ErrorMessage = "Price must be a positive number and not more than 7 digits.")]
        public decimal Price { get; set; }
        [Required]
        public string? Theme { get; set; }
        [Required]
        public string? Package { get; set; }
        [Required]
        [Range(0, 500)]
        public int MaxPeople { get; set; }
        public string ImageUrl { get; set; } = null!;
        [Required]
        public int Request { get; set; }
        public bool Status { get; set; }

        public virtual Account Host { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
