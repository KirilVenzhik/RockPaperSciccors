namespace ServerAPI.Entityes
{
    public class GameEvent
    {
        public int Id { get; set; }
        public int Rounds { get; set; }
        public int CardsToOneHand { get; set; }
        public int TimePerRound { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
