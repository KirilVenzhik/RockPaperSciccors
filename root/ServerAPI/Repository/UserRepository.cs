using ServerAPI.Data;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        // GET
        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
        public User GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        // POST
        public bool CreateUser(User user)
        {
            var saved = _context.Add(user);
            return Save();
        }

        // PUT
        public bool UpdateUser(User user)
        {
            var saved = _context.Update(user);
            return Save();
        }

        // DELETE
        public bool DeleteUser(User deleteUser)
        {
            _context.Remove(deleteUser);
            return Save();
        }
        public bool DeleteUsers(List<User> deleteUsers)
        {
            _context.RemoveRange(deleteUsers);
            return Save();
        }

        // Other
        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
