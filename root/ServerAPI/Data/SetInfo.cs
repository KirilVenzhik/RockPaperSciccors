using ServerAPI.Entityes;
using System.ComponentModel.DataAnnotations;

namespace ServerAPI.Data
{
    public class SetInfo
    {
        public static void AddUser() 
        {
            using (var db = new MyDbContext())
            {
                var userInfo = new MUserInfo
                {
                    TotalWins = "0",
                    TotalLooses = "0",
                    WinStreak = "0"
                };

                var user = new MUser
                {
                    Gmail = "testuser1@gmail.com",
                    Nickname = "UserNickname",
                    Password = "UserPassword",
                    UserInfo = userInfo
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
