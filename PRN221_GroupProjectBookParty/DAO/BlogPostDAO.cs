using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BlogPostDAO
    {
        private static BlogPostDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public BlogPostDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static BlogPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogPostDAO();
                }
                return instance;
            }
        }
    }
}
