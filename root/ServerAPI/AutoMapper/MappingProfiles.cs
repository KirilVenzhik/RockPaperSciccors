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
            CreateMap<UserDto, User>();

            CreateMap<GameRoom, GameRoomDto>();
            CreateMap<GameRoomDto, GameRoom>();

            CreateMap<GameEvent, GameEventDto>();
            CreateMap<GameEventDto, GameEvent>();

            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
        }
    }
}
