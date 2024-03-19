using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FeedBackDAO
    {
        private static FeedBackDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public FeedBackDAO()
        {
            if (dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static FeedBackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedBackDAO();
                }
                return instance;
            }
        }
        public void CreateFeedBack(FeedBack feedback)
        {
            FeedBack fb = GetFeedBackById(feedback.Id);
            if (fb == null)
            {
                dbContext.Add(feedback);
                dbContext.SaveChanges();
            }
        }
        public FeedBack GetFeedBackById(int id)
        {
            return dbContext.FeedBacks.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateFeedBack(FeedBack feedback)
        {
            FeedBack fb = GetFeedBackById(feedback.Id);
            if (fb != null)
            {
                dbContext.Update(feedback);
                dbContext.SaveChanges();
            }
        }
        public void DeleteFeedBack(FeedBack feedback)
        {
            FeedBack fb = GetFeedBackById(feedback.Id);
            if (fb != null)
            {
                dbContext.Remove(feedback);
                dbContext.SaveChanges();
            }

        }
        public List<FeedBack> GetListFeedBack()
        {
            return dbContext.FeedBacks.ToList();
        }
    }
}