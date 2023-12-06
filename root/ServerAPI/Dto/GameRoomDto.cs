namespace ServerAPI.Dto
{
    public class GameRoomDto
    {
        public int Id { get; set; }
        public string RoomLink { get; set; }
        public int PlayerAmount { get; set; } = 8;
        public bool NeedAuthorisation { get; set; } = false;
    }
}
