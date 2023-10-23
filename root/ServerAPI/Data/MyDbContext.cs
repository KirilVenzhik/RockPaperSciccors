using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServerAPI.Entityes;

namespace ServerAPI.Data
{
    //Class makes DataBase
    public class MyDbContext : DbContext
    {
        public MyDbContext(){}
        public DbSet<MUser> Users { get; set; }
        public DbSet<MUserInfo> UsersInfo { get; set; }
        public DbSet<MTotalGameSettings> TotalGameSettings { get; set; }
        public DbSet<MGameRoom> GameRooms {  get; set; }
        public DbSet<MGameSettings> GameSettings { get; set; }
        public DbSet<MGameEvent> GameEvents { get; set; }
        public DbSet<MEndGame> EndGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rpsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
