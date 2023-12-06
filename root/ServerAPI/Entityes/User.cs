namespace ServerAPI.Entityes
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProfileId { get; set; } = 1;
        public bool isAuthorised { get; set; } = false;
        public int Volume { get; set; } = 50;
        public GameRoom? GameRoom { get; set; } = null;
    }
}