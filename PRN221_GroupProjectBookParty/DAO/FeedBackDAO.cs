using BO;

namespace DAO;

public class FeedBackDAO
{
    private static FeedBackDAO instance;
    private readonly BookingPartyContext dbContext;

    public FeedBackDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static FeedBackDAO Instance
    {
        get
        {
            if (instance == null) instance = new FeedBackDAO();
            return instance;
        }
    }
}