using Microsoft.EntityFrameworkCore;
using Repositories.EntitiesConfiguration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class BookingDatabaseContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingHotelOption> BookingHotelOptions { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Commodity> Commodities { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelOption> HotelOptions { get; set; }

        public DbSet<HotelHotelOption> HotelHotelOptions { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomCategory> RoomCategories { get; set; }

        public DbSet<RoomCommodity> RoomCommodities { get; set; }

        public DbSet<RoomPhoto> RoomPhotos { get; set; }

        public DbSet<SupportRequest> SupportRequests { get; set; }

        public DbSet<User> Users { get; set; }


        public BookingDatabaseContext()
        {
        }

        public BookingDatabaseContext(DbContextOptions<BookingDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Booking>(new BookingConfiguration());
            modelBuilder.ApplyConfiguration<BookingHotelOption>(new BookingHotelOptionsConfiguration());
            modelBuilder.ApplyConfiguration<ChatMessage>(new ChatMessageConfiguration());
            modelBuilder.ApplyConfiguration<Commodity>(new CommodityConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration<Feedback>(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration<Hotel>(new HotelConfiguration());
            modelBuilder.ApplyConfiguration<HotelOption>(new HotelOptionConfiguration());
            modelBuilder.ApplyConfiguration<HotelHotelOption>(new HotelHotelOptionConfiguration());
            modelBuilder.ApplyConfiguration<Notification>(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration<Room>(new RoomConfiguration());
            modelBuilder.ApplyConfiguration<RoomCategory>(new RoomCategoryConfiguration());
            modelBuilder.ApplyConfiguration<RoomCommodity>(new RoomCommodityConfiguration());
            modelBuilder.ApplyConfiguration<RoomPhoto>(new RoomPhotoConfiguration());
            modelBuilder.ApplyConfiguration<SupportRequest>(new SupportRequestConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
