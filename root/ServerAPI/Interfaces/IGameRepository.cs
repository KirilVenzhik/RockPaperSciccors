using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameRepository
    {
        // GET
        ICollection<Game> GetGames();
        Game GetGame(int gameId);
        GameEvent GetGameEventByGameId(int gameId);

        // POST
        bool CreateGame(int roomId, int eventId, Game createGame);

        // PUT
        bool UpdateGame(int gameId, Game updateGame);

        // DELETE
        bool DeleteGame(Game deleteGame);
        bool DeleteGames(List<Game> deleteGames);

        // Other
        bool GameExists(int gameId);
        bool Save();
    }
}
