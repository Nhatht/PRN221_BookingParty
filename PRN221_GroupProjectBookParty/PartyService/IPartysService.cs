﻿namespace PartyService;
﻿using BO;
using PartyService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPartysService
{
}
    public interface IPartysService
    {
        public List<Party> GetAllParties();
        public Task<bool> AddParty(Party party);
        public List<Account> GetAllHost();
        public Task<Party> GetPartyById(int id);
        public Task<bool> DeleteParty(int id);
    }
}
