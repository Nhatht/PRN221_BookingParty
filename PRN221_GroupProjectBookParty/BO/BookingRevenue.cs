using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BookingRevenue
    {
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string PartyName { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
