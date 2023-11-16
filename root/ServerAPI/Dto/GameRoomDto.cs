namespace ServerAPI.Dto
{
    public class GameRoomDto
    {
        public int Id { get; set; }
        public string RoomLink { get; set; }
        public int PlayerAmount { get; set; }
        public bool NeedAuthorisation { get; set; } = false;
    }
}
