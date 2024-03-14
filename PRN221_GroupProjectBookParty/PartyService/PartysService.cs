using BO;
using PartyRepository;
using PartyService.PhotoUpload;
using PartyService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class PartysService : IPartysService
    {
        private IPartyRepo _partyRepo = null;
        private readonly IPhotoService _photoService;
        public PartysService(IPhotoService photoService)
        {
            _partyRepo = new PartyRepo();
            _photoService = photoService;
        }

        public async Task<bool> AddParty(Party party)
        {          
           return await _partyRepo.AddParty(party);          
        }

        public List<Party> GetAllParties()
        {
            return _partyRepo.GetAllParties();
        }
        public List<Account> GetAllHost()
        {
            return _partyRepo.GetAllHost();
        }

        public Task<Party> GetPartyById(int id)
        {
            return _partyRepo.GetPartyById(id);
        }

        public Task<bool> DeleteParty(int id)
        {
            return _partyRepo.DeleteParty(id);
        }
    }
}
