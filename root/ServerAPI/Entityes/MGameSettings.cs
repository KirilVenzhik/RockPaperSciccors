namespace ServerAPI.Entityes;
public class MGameSettings
{
    public int Id { get; set; }
    public int PlayersAmount { get; set; }
    public MGameRoom GameRoom { get; set; } = null!;
    public MGameEvent GameEvent { get; set; } = null!;
}