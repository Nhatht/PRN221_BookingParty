using PartyRepository;
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
        public PartysService()
        {
            _partyRepo = new PartyRepo();
        }
    }
}
