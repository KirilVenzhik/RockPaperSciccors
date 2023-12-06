using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Dto;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;
using ServerAPI.Repository;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IGameRoomRepository _roomRepository;
        private readonly IGameEventRepository _eventRepository;

        public GameController(IGameRepository gameRepository,
            IMapper mapper,
            IGameRoomRepository roomRepository,
            IGameEventRepository eventRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _roomRepository = roomRepository;
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public IActionResult GetGames()
        {
            var games = _mapper.Map<List<GameDto>>(_gameRepository.GetGames());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(games);
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
                return NotFound();

            var game = _mapper.Map<GameDto>(_gameRepository.GetGame(gameId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);
        }

        [HttpGet("events/{gameId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        [ProducesResponseType(400)]
        public IActionResult GetGameEventByGameId(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
                return NotFound();

            var _event = _mapper.Map<GameEventDto>(_gameRepository.GetGameEventByGameId(gameId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_event);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGame([FromBody] GameDto gameCreate,
            [FromQuery] int roomId,
            [FromQuery] int eventId)
        {
            if (gameCreate == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_roomRepository.GameRoomExists(roomId))
            {
                ModelState.AddModelError("", "There is no room with this ID");
                return StatusCode(442, ModelState);
            }

            if (!_eventRepository.GameEventExists(eventId))
            {
                ModelState.AddModelError("", "There is no event with this ID");
                return StatusCode(442, ModelState);
            }

            if (_roomRepository.GetUsersInRoom(roomId).Count() < 2)
            {
                ModelState.AddModelError("", "You need more then one users to start the game");
                return StatusCode(442, ModelState);
            }

            if (_roomRepository.GetGameByRoomId(roomId) != null)
            {
                ModelState.AddModelError("", "Game is already runs in this room");
                return StatusCode(442, ModelState);
            }

            var gameMap = _mapper.Map<Game>(gameCreate);
            gameMap.Room = _roomRepository.GetGameRoom(roomId);
            gameMap.GEvent = _eventRepository.GetGameEvent(eventId);

            if (!_gameRepository.CreateGame(roomId, eventId, gameMap))
            {
                ModelState.AddModelError("", "Someting went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{gameId}")]
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGame(int gameId, [FromBody] GameDto updatedGame)
        {
            if (updatedGame == null || !_gameRepository.GameExists(gameId) || !ModelState.IsValid)
                return BadRequest(ModelState);

            var gameMap = _mapper.Map<Game>(updatedGame);

            if (!_gameRepository.UpdateGame(gameId, gameMap))
            {
                ModelState.AddModelError("", "Something went wrong updating game");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
            {
                return NotFound();
            }

            var gameToDelete = _gameRepository.GetGame(gameId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_gameRepository.DeleteGame(gameToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
