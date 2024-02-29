using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public AccountDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
    }
}
