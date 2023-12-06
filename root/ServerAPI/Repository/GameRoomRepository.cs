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

        // GET
        public ICollection<GameRoom> GetGameRooms()
        {
            return _context.GameRooms.ToList();
        }
        public GameRoom GetGameRoom(int roomId)
        {
            return _context.GameRooms.FirstOrDefault(r => r.Id == roomId);
        }
        public GameRoom GetRoomByGameId(int gameId)
        {
            return _context.Games
                .Where(r => r.Id == gameId)
                .Select(r => r.Room)
                .FirstOrDefault();
        }
        public ICollection<User> GetUsersInRoom(int roomId)
        {
            return _context.Users
                .Where(u => u.GameRoom.Id == roomId)
                .ToList();
        }
        public Game GetGameByRoomId(int roomId)
        {
            return _context.Games.FirstOrDefault(g => g.Room.Id == roomId);
        }

        // POST
        public bool CreateGameRoom(int userId, GameRoom gameRoom)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            gameRoom.Users.Add(user);
            _context.GameRooms.Add(gameRoom);

            return Save();
        }

        // PUT
        public bool UpdateGameRoom(int userId, bool userToDelete, GameRoom gameRoom)
        {
            _context.Update(gameRoom);

            if (userToDelete)
            {
                var userToRemove = gameRoom.Users.FirstOrDefault(u => u.Id == userId);
                if (userToRemove != null)
                    gameRoom.Users.Remove(userToRemove);
            }
            else
            {
                var userToAdd = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (userToAdd != null)
                    gameRoom.Users.Add(userToAdd);
            }
            
            return Save();
        }

        // DELETE
        public bool DeleteRoom(GameRoom deleteRoom)
        {
            _context.Remove(deleteRoom);
            return Save();
        }
        public bool DeleteRooms(List<GameRoom> deleteRoom)
        {
            _context.RemoveRange(deleteRoom);
            return Save();
        }

        // Other
        public bool GameRoomExists(int roomId)
        {
            return _context.GameRooms.Any(r => r.Id == roomId);
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
