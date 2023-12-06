using ServerAPI.Entityes;

namespace ServerAPI.Interfaces
{
    public interface IUserRepository
    {
        // GET
        ICollection<User> GetUsers(); 
        User GetUser(int userId);
        User GetUser(string username);

        // POST
        bool CreateUser(User user);

        // PUT
        bool UpdateUser(User user);

        // DELETE
        bool DeleteUser(User deleteUser);

        // Other
        bool UserExists(int userId);
        bool Save();
    }
}
