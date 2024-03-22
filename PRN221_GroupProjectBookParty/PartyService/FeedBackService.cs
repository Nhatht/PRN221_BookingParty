using BO;
using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
	public class FeedBackService : IFeedBackService
	{
		private IFeedBackRepo _feedBackRepo = null;
		public FeedBackService()
		{
			_feedBackRepo = new FeedBackRepo();
		}
		public void CreateFeedBack(FeedBack feedback)
		{
			_feedBackRepo.CreateFeedBack(feedback);
		}
		public void DeleteFeedBack(FeedBack feedback)
		{
			_feedBackRepo.DeleteFeedBack(feedback);
		}
		public void UpdateFeedBack(FeedBack feedback)
		{
			_feedBackRepo.UpdateFeedBack(feedback);
		}
		public List<FeedBack> GetListFeedBack()
		{
			return _feedBackRepo.GetListFeedBack();
		}
		public FeedBack GetFeedBackById(int id)
		{
			return _feedBackRepo.GetFeedBackById(id);
		}
		public Booking GetBookingById(int id)
		{
			return _feedBackRepo.GetBookingById(id);
		}

	}
}
