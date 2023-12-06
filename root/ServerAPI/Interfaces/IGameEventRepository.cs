using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameEventRepository
    {
        // GET
        ICollection<GameEvent> GetGameEvents();
        GameEvent GetGameEvent(int eventId);
        ICollection<Game> GetGamesByEventId(int eventId);
        GameEvent GetEventByGameId(int gameId);

        // POST
        bool CreateGameEvent(GameEvent gameEvent);

        // PUT
        bool UpdateEvent(int eventId, GameEvent updateEvent);

        // DELETE
        bool DeleteEvent(GameEvent deleteEvent);
        bool DeleteEvents(List<GameEvent> deleteEvents);

        //Other
        bool GameEventExists (int eventId);
        bool Save();
    }
}
