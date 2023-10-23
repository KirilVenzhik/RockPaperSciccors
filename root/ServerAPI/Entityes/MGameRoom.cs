namespace ServerAPI.Entityes;
public class MGameRoom
{
    public int Id { get; set; }
    public ICollection<MUser> Players { get; set; } = null!;
}