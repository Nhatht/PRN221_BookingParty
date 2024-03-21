using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public class FeedBackRepo : IFeedBackRepo
    {
        public void CreateFeedBack(FeedBack feedback) => FeedBackDAO.Instance.CreateFeedBack(feedback);
        public void UpdateFeedBack(FeedBack feedback) => FeedBackDAO.Instance.UpdateFeedBack(feedback);
        public void DeleteFeedBack(FeedBack feedback) => FeedBackDAO.Instance.DeleteFeedBack(feedback);
        public List<FeedBack> GetListFeedBack() => FeedBackDAO.Instance.GetListFeedBack();
        public FeedBack GetFeedBackById(int id) => FeedBackDAO.Instance.GetFeedBackById(id);
		public Booking GetBookingById(int id) => FeedBackDAO.Instance.GetBookingById(id);

	}
}
