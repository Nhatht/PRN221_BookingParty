using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BO
{
    public partial class BookingPartyContext : DbContext
    {
        public BookingPartyContext()
        {
        }

        public BookingPartyContext(DbContextOptions<BookingPartyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<BlogPost> BlogPosts { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<FeedBack> FeedBacks { get; set; } = null!;
        public virtual DbSet<Party> Parties { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config.GetConnectionString("DBDefault");
            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.ToTable("BlogPost");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.Property(e => e.PageTitle).HasMaxLength(255);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Short_Description");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlogPosts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpost_account_id_foreign");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Inquiry).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('Not Approved')");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_gusetid_foreign");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_partyid_foreign");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.ReviewDate).HasColumnType("datetime");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_guestid_foreign");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_partyid_foreign");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("Party");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Image_Url");

                entity.Property(e => e.MaxPeople).HasColumnName("Max_People");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Package).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Request).HasDefaultValueSql("('0')");

                entity.Property(e => e.Theme).HasMaxLength(255);

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Parties)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("party_hostid_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
