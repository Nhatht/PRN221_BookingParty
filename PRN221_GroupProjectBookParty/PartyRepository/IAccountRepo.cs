﻿namespace PartyRepository;
﻿using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccountRepo
{
}
    public interface IAccountRepo
    {
        public bool Login(string email, string password);
        public void AddAccount(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(Account account);
        public Account GetAccountByEmail(string email);
        public List<Account> GetListAccount();
        public Account GetAccountById(int id);
    }
}
