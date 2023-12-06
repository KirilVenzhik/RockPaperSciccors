using ServerAPI.Entityes;

namespace ServerAPI.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int? Winner { get; set; } = null;
        public int? Losers { get; set; } = null;
    }
}
