namespace PartyRepository;
﻿using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AccountRepo : IAccountRepo
{
}
    public class AccountRepo : IAccountRepo
    {
        public bool Login(string email, string password) => AccountDAO.Instance.Login(email, password);
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);
        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
        public void DeleteAccount(Account account)=> AccountDAO.Instance.DeleteAccount(account);
        public Account GetAccountByEmail(string email)=> AccountDAO.Instance.GetAccountByEmail(email);
        public List<Account> GetListAccount() => AccountDAO.Instance.GetListAccount();
        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);
    }
}
