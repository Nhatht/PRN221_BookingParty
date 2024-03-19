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
        public Party GetPartyByIdNoAsync(int id)
        {
            return _partyRepo.GetPartyByIdNoAsync(id);
        }

        public Task<bool> DeleteParty(int id)
        {
            return _partyRepo.DeleteParty(id);
        }

        public async Task<bool> UpdateParty(Party party)
        {
            return await _partyRepo.UpdateParty(party);
        }

        public async Task<Party> GetPartyByIdNoTracking(int id)
        {
            return await _partyRepo.GetPartyByIdNoTracking(id);
        }
    }
}
