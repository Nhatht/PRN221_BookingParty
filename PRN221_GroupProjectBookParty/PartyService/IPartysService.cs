using BO;
using PartyService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public interface IPartysService
    {
        public List<Party> GetAllParties();
        public Task<bool> AddParty(Party party);
        public List<Account> GetAllHost();
        public Task<Party> GetPartyById(int id);
        public Task<bool> DeleteParty(int id);

        public Task<bool> UpdateParty(Party party);
        public Party GetPartyByIdNoAsync(int id);
        public Task<Party> GetPartyByIdNoTracking(int id);
        List<Party> GetPartyByHostId(int id);
        public List<Party> GetAllPartyByStatusTrue();
    }
}
