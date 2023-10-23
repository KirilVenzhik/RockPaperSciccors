namespace ServerAPI.Entityes;
public class MGameEvent
{
    public int Id { get; set; }
    public string GameEventName { get; set; } = null!;
    public int Rounds {  get; set; }
    public int Time {  get; set; }
}