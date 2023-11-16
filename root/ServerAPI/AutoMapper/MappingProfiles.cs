using AutoMapper;
using ServerAPI.Dto;
using ServerAPI.Entityes;

namespace ServerAPI.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<GameEvent, GameEventDto>();
            CreateMap<GameRoom, GameRoomDto>();
            CreateMap<Game, GameDto>();
        }
    }
}
