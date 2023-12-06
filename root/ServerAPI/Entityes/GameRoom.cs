namespace ServerAPI.Entityes
{
    public class GameRoom
    {
        public int Id { get; set; }
        public string RoomLink { get; set; }
        public int PlayerAmount { get; set; } = 8;
        public bool NeedAuthorisation { get; set; } = false;
        public ICollection<User> Users { get; set; }
        public Game? Game { get; set; }
    }
}