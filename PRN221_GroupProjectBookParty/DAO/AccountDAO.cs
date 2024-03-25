using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public AccountDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
        public Account GetAccount(string email, string password)
        {
            return dbContext.Accounts.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }
        public bool Login(string email, string password)
        {
            var user = dbContext.Accounts.FirstOrDefault(x => x.Email.Equals(email)
                                                    && x.Password.Equals(password));
            if (user == null)
            {
                //không tìm thấy user
                return false;
            }
            return true;
        }
        public void AddAccount(Account account)
        {
            //Check id đã tồn tại hay chưa trước khi add
            Account acc = GetAccountById(account.Id);
            if (acc == null)
            {
                dbContext.Add(account);
                dbContext.SaveChanges();
            }
        }
        public void UpdateAccount(Account account)
        {
            //Check id đã tồn tại hay chưa trước khi update
            Account acc = GetAccountById(account.Id);
            if (acc != null)
            {
                dbContext.Update(account);
                dbContext.SaveChanges();
            }

        }
        public void DeleteAccount(Account account)
        {
            //Check id đã tồn tại hay chưa trước khi xóa
            Account acc = GetAccountById(account.Id);
            if (acc != null)
            {
                account.Status = false;
                dbContext.Update(account);
                dbContext.SaveChanges();
            }

        }
        public Account GetAccountByEmail(string email)
        {
            return dbContext.Accounts.FirstOrDefault(y => y.Email.Equals(email));
        }
        public List<Account> GetListAccount()
        {
            return dbContext.Accounts.ToList();
        }
        public Account GetAccountById(int id)
        {
            return dbContext.Accounts.FirstOrDefault(x =>x.Id == id);
        }
        public List<Account> GetAccountByRole(string role)
        {
            return dbContext.Accounts.Where(p => p.Role.Equals(role)).ToList();
        }
    }
}
