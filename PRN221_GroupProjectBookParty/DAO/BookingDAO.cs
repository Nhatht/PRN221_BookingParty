using BO;
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
            if(dbContext == null)
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
        public Booking GetBookingById(int id)
        {
            return dbContext.Bookings.FirstOrDefault(x => x.Id == id);
        }
        public List<Booking> GetBookingByAccountId(int id)
        {
            return dbContext.Bookings.Where(x => x.Id == id).ToList();
        }
        public void AddBooking(Booking booking)
        {
            //Check id đã tồn tại hay chưa trước khi add
            Booking bk = GetBookingById(booking.Id);
            if (bk == null)
            {
                dbContext.Add(booking);
                dbContext.SaveChanges();
            }
        }
        public void UpdateBooking(Booking booking)
        {
            //Check id đã tồn tại hay chưa trước khi update
            Booking bk = GetBookingById(booking.Id);
            if (bk != null)
            {
                dbContext.Update(booking);
                dbContext.SaveChanges();
            }
        }
        public void DeleteBooking(int id)
        {
            Booking bk = GetBookingById(id);
            if (bk != null)
            {
                dbContext.Remove(bk);
                dbContext.SaveChanges();
            }
        }
        public List<Booking> GetBookingByHostId(int id)
        {
            var party = dbContext.Parties.Where(x => x.HostId == id).ToList();
            List<Booking> bookings = new List<Booking>();
            foreach (var item in party)
            {
                bookings.AddRange(dbContext.Bookings.Where(x => x.PartyId == item.Id).ToList());
            }
            return bookings;
        }
    }
}
