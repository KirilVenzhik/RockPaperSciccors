using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerAPI.Dto;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;
using ServerAPI.Repository;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRoomController : Controller
    {
        private readonly IGameRoomRepository _gameRoomRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GameRoomController(IGameRoomRepository gameRoomRepository,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _gameRoomRepository = gameRoomRepository;
            _mapper = mapper;
            _userRepository = userRepository;
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

        [HttpGet("game/{roomId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGameByRoomId(int roomId)
        {
            if (!_gameRoomRepository.GameRoomExists(roomId))
                return NotFound();

            var games = _mapper.Map<GameDto>(_gameRoomRepository.GetGameByRoomId(roomId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(games);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRoom([FromQuery] int userId, [FromBody] GameRoomDto gameRoomCreate)
        {
            if (gameRoomCreate == null)
                return BadRequest(ModelState);

            var room = _gameRoomRepository.GetGameRooms()
                .Where(r => r.RoomLink.ToUpper() == gameRoomCreate.RoomLink.ToUpper())
                .FirstOrDefault();

            if (room != null)
            {
                ModelState.AddModelError("", "The same connection links cannot be in different rooms.");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameRoomMap = _mapper.Map<GameRoom>(gameRoomCreate);
            gameRoomMap.Users = _userRepository.GetUsers().Where(u => u.Id == userId).ToList();

            if (!_gameRoomRepository.CreateGameRoom(userId, gameRoomMap))
            {
                ModelState.AddModelError("", "Someting went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{roomId}")]
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRoom(int roomId, [FromBody] GameRoomDto updatedRoom,
            [FromQuery] int userId,
            [FromQuery] bool userToDelete)
        {
            if (updatedRoom == null || !_gameRoomRepository.GameRoomExists(roomId) || !ModelState.IsValid)
                return BadRequest(ModelState);

            var roomMap = _mapper.Map<GameRoom>(updatedRoom);
            roomMap.Users = _gameRoomRepository.GetUsersInRoom(roomId).ToList();

            if (!_gameRoomRepository.UpdateGameRoom(userId, userToDelete, roomMap))
            {
                ModelState.AddModelError("", "Something went wrong updating gameRoom");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{roomId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRoom(int roomId)
        {
            if (!_gameRoomRepository.GameRoomExists(roomId))
            {
                return NotFound();
            }

            var roomToDelete = _gameRoomRepository.GetGameRoom(roomId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //создать проверку на то, существует ли игра сейчас в этой комнате.
            if (_gameRoomRepository.GetGameByRoomId(roomId) != null)
            {
                ModelState.AddModelError("", "Unable to delete while the game is in progress.");
                return StatusCode(400, ModelState);
            }

            //переписать код так что бы создавалась проверка на то, есть ли юзеры в комнатах
            /*
            var users = _userRepository.GetUsers().Where(u => u.GameRoom.Id == roomId).ToList();
            foreach (var user in users)
                user.GameRoom = null;
            */
            if(_gameRoomRepository.GetUsersInRoom(roomId).Any())
            {
                ModelState.AddModelError("", "Unable to delete while users are in the room.");
                return StatusCode(400, ModelState);
            }

            if (!_gameRoomRepository.DeleteRoom(roomToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
