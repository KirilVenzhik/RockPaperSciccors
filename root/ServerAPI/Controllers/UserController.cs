using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerAPI.Data;
using ServerAPI.Entityes;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public IEnumerable<MUser> Get()
        {
            using (var db = new MyDbContext())
            {
                var userData = db.Users.ToList();
                return userData.Select(index => new MUser
                {
                    Id = index.Id,
                    Gmail = index.Gmail,
                    Nickname = index.Nickname,
                    Password = index.Password,
                    UserInfo = index.UserInfo,
                })
                .ToArray();
            }
        }
    }
}
