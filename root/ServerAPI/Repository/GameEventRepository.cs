using ServerAPI.Data;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Repository
{
    public class GameEventRepository : IGameEventRepository
    {
        private readonly DataContext _context;

        public GameEventRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<GameEvent> GetGameEvents()
        {
            return _context.GameEvents.ToList();
        }

        public GameEvent GetGameEvent(int eventId)
        {
            return _context.GameEvents.FirstOrDefault(e => e.Id == eventId);
        }

        public ICollection<Game> GetGamesByEventId(int eventId)
        {
            return _context.Games
                .Where(g => g.GEvent.Id == eventId)
                .ToList();
        }

        public bool GameEventExists(int id)
        {
            return _context.GameEvents.Any(e => e.Id == id);
        }
    }
}
