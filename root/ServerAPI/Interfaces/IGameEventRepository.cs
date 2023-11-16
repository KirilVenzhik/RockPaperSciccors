using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameEventRepository
    {
        public ICollection<GameEvent> GetGameEvents();
        public GameEvent GetGameEvent(int eventId);
        public ICollection<Game> GetGamesByEventId(int eventId);
        public bool GameEventExists (int eventId);
    }
}
