using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;

namespace RCS_IKT2_DEC18.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public DbSet<Models.RoomType> RoomTypes { get; set; }
        public DbSet<Models.Room> Rooms { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Models.Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Review>()
                .Property(m => m.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Models.Booking>()
                .Property(m => m.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Models.Booking>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Booking_Checkin_Checkout",
                    "[CheckOut] > [CheckIn]"));
        }
    }
}
