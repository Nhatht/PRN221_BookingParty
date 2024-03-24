using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO
{
    public class PartyDAO
    {
        private static PartyDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public PartyDAO()
        {
            if (dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static PartyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartyDAO();
                }
                return instance;
            }
        } 

        public List<Party> GetAllPartyByStatusTrue()
        {
            return dbContext.Parties.Where(p => p.Status == true).Include(p => p.Bookings).Include(p => p.FeedBacks)
                .Include(p => p.Host).ToList();
        }
        public List<Party> GetAllParties()
        {
            return dbContext.Parties.Include(p => p.Bookings).Include(p => p.FeedBacks)
                .Include(p => p.Host).ToList();
        }
        public List<Party> GetPartyByHostId(int id)
        {
            return dbContext.Parties.Where(p => p.HostId == id).Include(p => p.FeedBacks)
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
        public Party GetPartyByIdNoAsync(int id)
        {
            return dbContext.Parties.FirstOrDefault(p => p.Id.Equals(id));
        }
        public async Task<Party> GetPartyByIdNoTracking(int id)
        {
            return await dbContext.Parties.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
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
            bool result = false;
            Party party1 = await GetPartyById(party.Id);
            try
            {
                if (party1 != null)
                {
                    party1.Description = party.Description;
                    party1.Name = party.Name;
                    party1.City = party.City;
                    party1.Price = party.Price;
                    party1.Theme = party.Theme;
                    party1.Package = party.Package;
                    party1.MaxPeople = party.MaxPeople;
                    party1.ImageUrl = party.ImageUrl;
                    party1.Status = party.Status;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }
        public List<Account> GetAllHost()
        {
            return dbContext.Accounts.ToList();
        }

    }
}
