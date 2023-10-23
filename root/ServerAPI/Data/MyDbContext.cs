using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServerAPI.Entityes;

namespace ServerAPI.Data
{
    //Class makes DataBase
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           :base(options)
        {

        }
        public DbSet<MUser> Users { get; set; }
        public DbSet<MUserInfo> UsersInfo { get; set; }
        public DbSet<MTotalGameSettings> TotalGameSettings { get; set; }
        public DbSet<MGameRoom> GameRooms {  get; set; }
        public DbSet<MGameSettings> GameSettings { get; set; }
        public DbSet<MGameEvent> GameEvents { get; set; }
        public DbSet<MEndGame> EndGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=rpsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
