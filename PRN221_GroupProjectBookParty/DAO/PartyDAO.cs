using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO;

public class PartyDAO
{
    private static PartyDAO instance;
    private readonly BookingPartyContext dbContext;

    public PartyDAO()
    {
        if (dbContext == null) dbContext = new BookingPartyContext();
    }

    public static PartyDAO Instance
    {
        get
        {
            if (instance == null) instance = new PartyDAO();
            return instance;
        }

         public List<Party> GetAllParties()
        {
            return  dbContext.Parties.Include(p => p.Bookings).Include(p => p.FeedBacks)
                .Include(p => p.Host).ToList();
        }
        public async Task<bool> AddParty(Party party)
        {
            bool result = false;
            try
            {
                dbContext.Add(party);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public async Task<Party> GetPartyById(int id)
        {
            return await dbContext.Parties.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
        //public async Task<Party> GetPartyByIdNoTracking(int id)
        //{
        //    return 
        //}
        public async Task<bool> DeleteParty(int id)
        {
            bool result = false;
            Party deleteParty = await GetPartyById(id);
            try
            {
                dbContext.Remove(deleteParty);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public async Task<bool> UpdateParty(Party party)
        {
            return false;
        }
        public List<Account> GetAllHost()
        {
            return dbContext.Accounts.ToList();
        }

    }
}