using BO;

namespace DAO;

public class PartyDAO
{
    private static PartyDAO instance;
    private readonly BookingPartyContext dbContext;

    public PartyDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static PartyDAO Instance
    {
        get
        {
            if (instance == null) instance = new PartyDAO();
            return instance;
        }
    }
}