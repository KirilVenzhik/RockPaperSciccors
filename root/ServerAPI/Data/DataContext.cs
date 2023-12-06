using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServerAPI.Entityes;

namespace ServerAPI.Data
{
    //Class makes DataBase
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameRoom>()
                .HasOne(r => r.Game)
                .WithOne(g => g.Room)
                .HasForeignKey<Game>(g => g.Id);
        }
    }
}
