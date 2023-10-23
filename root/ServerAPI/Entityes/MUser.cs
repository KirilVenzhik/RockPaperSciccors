namespace ServerAPI.Entityes;
public class MUser
{
    public int Id { get; set; }
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public MUserInfo UserInfo { get; set; } = null!;
}