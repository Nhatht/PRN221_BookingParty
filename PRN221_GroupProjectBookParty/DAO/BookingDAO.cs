using BO;

namespace DAO;

public class BookingDAO
{
    private static BookingDAO instance;
    private readonly BookingPartyContext dbContext;

    public BookingDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static BookingDAO Instance
    {
        get
        {
            if (instance == null) instance = new BookingDAO();
            return instance;
        }
    }
}