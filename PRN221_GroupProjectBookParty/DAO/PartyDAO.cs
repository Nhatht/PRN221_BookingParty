using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PartyDAO
    {
        private static PartyDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public PartyDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static PartyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartyDAO();
                }
                return instance;
            }
        }
    }
}
