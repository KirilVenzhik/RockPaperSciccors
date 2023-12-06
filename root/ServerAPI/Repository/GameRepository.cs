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

        // GET
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

        // POST
        public bool CreateGame(int roomId, int eventId, Game createGame)
        {
            var room = _context.GameRooms.FirstOrDefault(r => r.Id == roomId);
            var _event = _context.GameEvents.FirstOrDefault(e => e.Id == eventId);

            if (room == null || _event == null)
            {
                return false;
            }

            createGame.Room = room;
            createGame.GEvent = _event;
            var saved = _context.Add(createGame);
            return Save();
        }

        // PUT
        public bool UpdateGame(int gameId, Game updateGame)
        {
            var saved = _context.Update(updateGame);
            return Save();
        }

        // DELETE
        public bool DeleteGame(Game deleteGame)
        {
            _context.Remove(deleteGame);
            return Save();
        }
        public bool DeleteGames(List<Game> deleteGames)
        {
            _context.RemoveRange(deleteGames);
            return Save();
        }

        // Otheer
        public bool GameExists(int gameId)
        {
            return _context.Games.Any(g => g.Id == gameId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
