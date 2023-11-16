using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers(); 
        public User GetUser(int userId);
        public User GetUser(string username);
        public bool UserExists(int userId);
    }
}
