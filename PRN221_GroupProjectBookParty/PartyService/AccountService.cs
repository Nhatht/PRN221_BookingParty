using PartyRepository;

namespace PartyService;

public class AccountService : IAccountService
{
    private IAccountRepo _accountRepo;

    public AccountService()
    {
        _accountRepo = new AccountRepo();
    }
}