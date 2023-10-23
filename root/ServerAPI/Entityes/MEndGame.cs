namespace ServerAPI.Entityes;
public class MEndGame
{
    public int Id { get; set; }
    public MGame Game { get; set; } = null!;
    public int Winers { get; set; }
    public int Losers { get; set; }
}