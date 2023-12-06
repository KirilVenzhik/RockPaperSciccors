using Microsoft.EntityFrameworkCore;
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

        // GET
        public ICollection<GameEvent> GetGameEvents()
        {
            return _context.GameEvents.ToList();
        }

        public GameEvent GetGameEvent(int eventId)
        {
            return _context.GameEvents.FirstOrDefault(e => e.Id == eventId);
        }

        public GameEvent GetEventByGameId(int gameId)
        {
            return _context.Games
                .Where(g => g.Id == gameId)
                .Select(e => e.GEvent)
                .FirstOrDefault();
        }

        public ICollection<Game> GetGamesByEventId(int eventId)
        {
            return _context.Games
                .Where(g => g.GEvent.Id == eventId)
                .ToList();
        }

        // POST
        public bool CreateGameEvent(GameEvent gameEvent)
        {
            var saved = _context.Add(gameEvent);
            return Save();
        }

        // PUT
        public bool UpdateEvent(int eventId, GameEvent updateEvent)
        {
            var saved = _context.Update(updateEvent);
            return Save();
        }

        // DELETE
        public bool DeleteEvent(GameEvent deleteEvent)
        {
            _context.Remove(deleteEvent);
            return Save();
        }
        public bool DeleteEvents(List<GameEvent> deleteEvents)
        {
            _context.RemoveRange(deleteEvents);
            return Save();
        }

        // Other
        public bool GameEventExists(int eventId)
        {
            return _context.GameEvents.Any(e => e.Id == eventId);
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
