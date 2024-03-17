using GolfClub.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfClub.Data
{
    public class GolfDbContext: DbContext
    {
        public GolfDbContext(DbContextOptions<GolfDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Golfer> Golfers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable(nameof(Booking));
            modelBuilder.Entity<Golfer>().ToTable(nameof(Golfer));

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Golfer)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GolferId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Player1) // Player1 is the property in Booking representing player one
                .WithMany()
                .HasForeignKey(b => b.Player1GolferId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasPrincipalKey(g => g.Id);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Player2) // Player2 is the property in Booking representing player two
                .WithMany()
                .HasForeignKey(b => b.Player2GolferId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasPrincipalKey(g => g.Id);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Player3) // Player3 is the property in Booking representing player three
                .WithMany()
                .HasForeignKey(b => b.Player3GolferId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasPrincipalKey(g => g.Id);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Player4) // Player4 is the property in Booking representing player four
                .WithMany()
                .HasForeignKey(b => b.Player4GolferId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasPrincipalKey(g => g.Id);






        }
    }
}
