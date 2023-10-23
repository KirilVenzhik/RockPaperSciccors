namespace ServerAPI.Entityes;
public class MUserInfo
{
    public int Id { get; set; }
    public string TotalWins { get; set; } = null!;
    public string TotalLooses {  get; set; } = null!;
    public string WinStreek { get; set; } = null!;
}