namespace ServerAPI.Dto
{
    public class GameEventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int Rounds { get; set; }
        public int CardsToOneHand { get; set; }
        public int TimePerRound { get; set; }
    }
}
