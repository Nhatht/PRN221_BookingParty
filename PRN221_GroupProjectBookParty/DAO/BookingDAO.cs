using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BookingDAO
    {
        private static BookingDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public BookingDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDAO();
                }
                return instance;
            }
        }
    }
}
