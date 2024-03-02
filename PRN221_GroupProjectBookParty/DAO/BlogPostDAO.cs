using BO;

namespace DAO;

public class BlogPostDAO
{
    private static BlogPostDAO instance;
    private readonly BookingPartyContext dbContext;

    public BlogPostDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static BlogPostDAO Instance
    {
        get
        {
            if (instance == null) instance = new BlogPostDAO();
            return instance;
        }
    }
}