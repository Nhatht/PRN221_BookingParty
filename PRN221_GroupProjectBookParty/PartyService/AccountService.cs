using BO;
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

        public void AddAccount(Account account)
        {
             _accountRepo.AddAccount(account);
        }

        public void DeleteAccount(Account account)
        {
            _accountRepo.DeleteAccount(account);
        }

        public Account GetAccountByEmail(string email)
        {
            return _accountRepo.GetAccountByEmail(email);
        }

        public bool Login(string email, string password)
        {
           return _accountRepo.Login(email, password);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepo.UpdateAccount(account);
        }
        public List<Account> GetListAccount()
        {
            return _accountRepo.GetListAccount();
        }
        public Account GetAccountById(int id)
        {
            return _accountRepo.GetAccountById(id);
        }
    }
}
