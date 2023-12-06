
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
                        UserName = "Player1",
                        ProfileId = 2
                    },
                    new User()
                    {
                        UserName = "Player2",
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
                    },
                    new GameEvent()
                    {
                        Rounds = 3,
                        CardsToOneHand = 2,
                        TimePerRound = 30
                    }
                };
                dataContext.GameEvents.AddRange(gameEvents);
                dataContext.SaveChanges();
            }

            if (!dataContext.Games.Any())
            {
                var game = new Game
                {
                    Room = new GameRoom
                    {
                        RoomLink = "http://xxx",
                        PlayerAmount = 3,
                        NeedAuthorisation = false,
                        Users = dataContext.Users
                        .Where(u => u.Id == 1 || u.Id == 2)
                        .ToList()
                    },
                    GEvent = dataContext.GameEvents.FirstOrDefault(e => e.Id == 1),
                };

                dataContext.Games.AddRange(game);
                dataContext.SaveChanges();
            }
        }
    }
}