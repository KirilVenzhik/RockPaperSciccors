namespace ServerAPI.Entityes;
public class MTotalGameSettings
{
    public int Id {  get; set; }
    public MUser User { get; set; } = null!;
    public int Volume { get; set; }
}