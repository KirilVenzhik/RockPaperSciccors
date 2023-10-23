namespace ServerAPI.Entityes;
public class MUser
{
    public int Id { get; set; }
    public string Gmail { get; set; }
    public string Nickname { get; set; }
    public string Password { get; set; }
    public MUserInfo UserInfo { get; set; }
}