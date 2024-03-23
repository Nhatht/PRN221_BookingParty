using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService.ViewModel
{
    public class AddBookingModel
    {
        public int GuestId { get; set; }
        public int PartyId { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumberOfPeople { get; set; }
        public string? Inquiry { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }
    }
}
