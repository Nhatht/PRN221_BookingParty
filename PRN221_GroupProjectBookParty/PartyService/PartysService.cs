using PartyRepository;

namespace PartyService;

public class PartysService : IPartysService
{
    private IPartyRepo _partyRepo;

    public PartysService()
    {
        _partyRepo = new PartyRepo();
    }
}