using ServerAPI.Data;
using ServerAPI.Entityes;

namespace ServerAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        UserName = "TestPlayer1",
                        ProfileId = 2
                    },
                    new User()
                    {
                        UserName = "TestPlayer2",
                        Volume = 60
                    }
                };

                dataContext.Users.AddRange(users);
                dataContext.SaveChanges();
            }
            if (!dataContext.GameEvents.Any())
            {
                var gameEvents = new List<GameEvent>()
                {
                    new GameEvent()
                    {
                        Rounds = 3,
                        CardsToOneHand = 3,
                        TimePerRound = 60
                    }
                };
                dataContext.GameEvents.AddRange(gameEvents);
                dataContext.SaveChanges();
            }

            if (!dataContext.GameRooms.Any())
            {
                var gameRooms = new List<GameRoom>()
                {
                    new GameRoom()
                    {
                        RoomLink = "http://xxx",
                        PlayerAmount = 8,
                        NeedAuthorisation = false,
                        Users = dataContext.Users
                        .Where(u => u.Id == 1 || u.Id == 2)
                        .ToList()
                    }
                };
                dataContext.GameRooms.AddRange(gameRooms);
                dataContext.SaveChanges();
            }

            if (!dataContext.Games.Any())
            {
                var games = new List<Game>()
                {
                    new Game()
                    {
                        GEvent = dataContext.GameEvents
                        .Where(e => e.Id == 1)
                        .FirstOrDefault(),
                        Room = dataContext.GameRooms
                        .Where(r => r.Id == 1)
                        .FirstOrDefault()
                    }
                };
                dataContext.Games.AddRange(games);
                dataContext.SaveChanges();
            }
        }
    }
}