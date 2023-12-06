using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameRoomRepository
    {
        // GET
        ICollection<GameRoom> GetGameRooms();
        GameRoom GetGameRoom(int roomId);
        ICollection<User> GetUsersInRoom(int roomId);
        Game GetGameByRoomId(int roomId);
        GameRoom GetRoomByGameId (int gameId);

        // POST
        bool CreateGameRoom(int userId, GameRoom gameRoom);

        // PUT
        bool UpdateGameRoom(int userId, bool userToDelete, GameRoom gameRoom);

        // DELETE
        bool DeleteRoom(GameRoom deleteRoom);
        bool DeleteRooms(List<GameRoom> deleteRooms);

        // Other
        bool GameRoomExists(int roomId);
        bool Save();
    }
}