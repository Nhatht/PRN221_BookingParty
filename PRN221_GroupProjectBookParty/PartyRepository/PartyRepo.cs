using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public class PartyRepo : IPartyRepo
    {
        public async Task<bool> AddParty(Party party) => await PartyDAO.Instance.AddParty(party);

        public List<Party> GetAllParties() => PartyDAO.Instance.GetAllParties();
        public List<Account> GetAllHost() => PartyDAO.Instance.GetAllHost();

        public async Task<Party> GetPartyById(int id) => await PartyDAO.Instance.GetPartyById(id);

        public async Task<bool> DeleteParty(int id) => await PartyDAO.Instance.DeleteParty(id);

        public async Task<bool> UpdateParty(Party party) => await PartyDAO.Instance.UpdateParty(party);
        public Party GetPartyByIdNoAsync(int id) => PartyDAO.Instance.GetPartyByIdNoAsync(id);

        public async Task<Party> GetPartyByIdNoTracking(int id) => await PartyDAO.Instance.GetPartyByIdNoTracking(id);
        public List<Party> GetPartyByHostId(int id) => PartyDAO.Instance.GetPartyByHostId(id);
    }
}
