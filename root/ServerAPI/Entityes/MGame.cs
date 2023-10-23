namespace ServerAPI.Entityes;
public class MGame
{
    public int Id { get; set; }
    public MGameSettings Settings { get; set; } = null!;
}