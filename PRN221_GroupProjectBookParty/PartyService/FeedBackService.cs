using PartyRepository;

namespace PartyService;

public class FeedBackService : IFeedBackService
{
    private IFeedBackRepo _feedBackRepo;

    public FeedBackService()
    {
        _feedBackRepo = new FeedBackRepo();
    }
}