using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IGameRoomRepository
    {
        public ICollection<GameRoom> GetGameRooms();
        public GameRoom GetGameRoom(int roomId);
        public ICollection<User> GetUsersInRoom(int roomId);
        public ICollection<Game> GetGamesByRoomId(int roomId);
        public bool GameRoomExists(int roomId);
    }
}