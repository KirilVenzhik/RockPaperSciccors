using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Dto;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameController(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
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
    }
}
