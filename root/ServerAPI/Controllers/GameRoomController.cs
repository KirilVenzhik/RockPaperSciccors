using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Dto;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRoomController : Controller
    {
        private readonly IGameRoomRepository _gameRoomRepository;
        private readonly IMapper _mapper;

        public GameRoomController(IGameRoomRepository gameRoomRepository, IMapper mapper)
        {
            _gameRoomRepository = gameRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameRoom>))]
        public IActionResult GetGameRooms()
        {
            var gameRoom = _mapper.Map<List<GameRoomDto>>(_gameRoomRepository.GetGameRooms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameRoom);
        }

        [HttpGet("{roomId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameRoom>))]
        [ProducesResponseType(400)]
        public IActionResult GetGameRoom(int roomId)
        {
            if (!_gameRoomRepository.GameRoomExists(roomId))
                return NotFound();

            var gameRoom = _mapper.Map<GameRoomDto>(_gameRoomRepository.GetGameRoom(roomId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameRoom);
        }

        [HttpGet("users/{roomId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsersByRoomId(int roomId)
        {
            if (!_gameRoomRepository.GameRoomExists(roomId))
                return NotFound();

            var users = _mapper.Map<List<UserDto>>(_gameRoomRepository.GetUsersInRoom(roomId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("games/{roomId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGamesByRoomId(int roomId)
        {
            if (!_gameRoomRepository.GameRoomExists(roomId))
                return NotFound();

            var games = _mapper.Map<List<GameDto>>(_gameRoomRepository.GetGamesByRoomId(roomId));
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(games);
        }
    }
}
