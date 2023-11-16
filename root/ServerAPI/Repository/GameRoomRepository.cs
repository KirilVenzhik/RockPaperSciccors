using AutoMapper;
using ServerAPI.Data;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Repository
{
    public class GameRoomRepository : IGameRoomRepository
    {
        private readonly DataContext _context;

        public GameRoomRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<GameRoom> GetGameRooms()
        {
            return _context.GameRooms.ToList();
        }

        public GameRoom GetGameRoom(int roomId)
        {
            return _context.GameRooms.FirstOrDefault(r => r.Id == roomId);
        }

        public ICollection<User> GetUsersInRoom(int roomId)
        {
            return _context.Users
                .Where(u => u.GameRoom.Id == roomId)
                .ToList();
        }

        public ICollection<Game> GetGamesByRoomId(int roomId)
        {
            return _context.Games
                .Where(g => g.Room.Id == roomId)
                .ToList();
        }

        public bool GameRoomExists(int roomId)
        {
            return _context.GameRooms.Any(r => r.Id == roomId);
        }
    }
}
