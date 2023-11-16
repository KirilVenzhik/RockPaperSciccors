using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameRepository
    {
        public ICollection<Game> GetGames();
        public Game GetGame(int gameId);
        public GameEvent GetGameEventByGameId(int gameId);
        public bool GameExists(int gameId);
    }
}
