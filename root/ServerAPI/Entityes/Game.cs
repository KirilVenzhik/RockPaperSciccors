namespace ServerAPI.Entityes
{
    public class Game
    {
        public int Id {  get; set; }
        public int? Winner { get; set; } = null;
        public int? Losers { get; set; } = null;
        public GameRoom Room { get; set; }
        public GameEvent GEvent { get; set; }
    }
}