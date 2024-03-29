﻿using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BookingDAO
    {
        private static BookingDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public BookingDAO()
        {
            if (dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDAO();
                }
                return instance;
            }
        }
        public List<Booking> GetAllBooking()
        {
            return dbContext.Bookings.Include(x => x.Guest).Include(x => x.Party).ToList();
        }
        public async Task<Booking> GetBookingById(int id)
        {
            return await dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
        public List<Booking> GetBookingByAccountId(int id)
        {
            return dbContext.Bookings.Where(x => x.Id == id).ToList();
        }
        public async Task AddBooking(Booking booking)
        {
            //Check id đã tồn tại hay chưa trước khi add
            var bk = await dbContext.Bookings.FirstOrDefaultAsync(x => x.StartDate == booking.StartDate && x.Id == booking.Id);
            if (bk == null)
            {
                await dbContext.AddAsync(booking);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateBooking(Booking booking)
        {
            //Check id đã tồn tại hay chưa trước khi update
            Booking bk = await GetBookingById(booking.Id);
            if (bk != null)
            {
                dbContext.Update(booking);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteBooking(int id)
        {
            Booking bk = await GetBookingById(id);
            if (bk != null)
            {
                dbContext.Remove(bk);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Booking>> GetBookingByHostId(int id)
        {
            var party =  dbContext.Parties.Where(x => x.HostId == id).ToList();
            List<Booking> bookings = new List<Booking>();
            foreach (var item in party)
            {
                 bookings.AddRange(dbContext.Bookings.Where(x => x.PartyId == item.Id).Include(x => x.Guest).ToList());
            }
            return bookings;
        }
        public List<Booking> GetBookingByUserId(int id)
        {
            return dbContext.Bookings.Where(x => x.GuestId == id).Include(x => x.Party).ToList();
        }
        public List<Booking> GetPayment()
        {
            return dbContext.Bookings                           
                            .Where(p => p.Status.Equals("Paid"))
                            .ToList();
        }

        public List<BookingRevenue> GetRevenueHost(int year)
        {
            var bookings = dbContext.Bookings
                .Include(p => p.Party)
                .Where(p => p.StartDate.Year == year && p.Status.Equals("Paid"))
                .ToList();

            var revenueByHost = bookings
                .GroupBy(b => b.Party.HostId)
                .Select(g => new BookingRevenue
                {
                    HostId = g.Key,
                    HostName = dbContext.Accounts.FirstOrDefault(a => a.Id == g.Key)?.UserName,
                    PartyName = dbContext.Parties.FirstOrDefault(p => p.HostId == g.Key)?.Name,
                    TotalRevenue = g.Sum(b => b.TotalPrice)
                })
                .OrderByDescending(r => r.TotalRevenue)
                .ToList();

            return revenueByHost;
        }
    }
}
