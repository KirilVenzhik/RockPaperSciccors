namespace ServerAPI.Entityes
{
    public class GameRoom
    {
        public int Id { get; set; }
        public string RoomLink { get; set; }
        public int PlayerAmount { get; set; }
        public bool NeedAuthorisation { get; set; } = false;
        public ICollection<User> Users { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}