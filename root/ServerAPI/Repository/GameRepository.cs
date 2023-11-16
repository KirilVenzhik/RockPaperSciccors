using ServerAPI.Data;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public Game GetGame(int gameId)
        {
            return _context.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public GameEvent GetGameEventByGameId(int gameId)
        {
            return _context.Games
                .Where(e => e.Id == gameId)
                .Select(e => e.GEvent)
                .FirstOrDefault();
        }

        public bool GameExists(int gameId)
        {
            return _context.Games.Any(g => g.Id == gameId);
        }
    }
}
