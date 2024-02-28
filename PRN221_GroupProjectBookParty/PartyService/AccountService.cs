using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class AccountService : IAccountService
    {
        private IAccountRepo _accountRepo = null;
        public AccountService()
        {
            _accountRepo = new AccountRepo();
        }
    }
}
