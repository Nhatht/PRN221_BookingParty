using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public interface IFeedBackRepo
    {
        public void CreateFeedBack(FeedBack feedback);
        public void UpdateFeedBack(FeedBack feedback);
        public void DeleteFeedBack(FeedBack feedback);
        public List<FeedBack> GetListFeedBack();
        public FeedBack GetFeedBackById(int id);
		public Booking GetBookingById(int id);

	}
}
