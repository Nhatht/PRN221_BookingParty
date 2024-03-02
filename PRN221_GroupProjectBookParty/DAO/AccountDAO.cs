using BO;

namespace DAO;

public class AccountDAO
{
    private static AccountDAO instance;
    private readonly BookingPartyContext dbContext;

    public AccountDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static AccountDAO Instance
    {
        get
        {
            if (instance == null) instance = new AccountDAO();
            return instance;
        }
    }
}