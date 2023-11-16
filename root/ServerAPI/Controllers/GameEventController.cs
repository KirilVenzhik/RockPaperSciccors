using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Dto;
using ServerAPI.Entityes;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameEventController : Controller
    {
        private readonly IGameEventRepository _gameEventRepository;
        private readonly IMapper _mapper;

        public GameEventController(IGameEventRepository gameEventRepository, IMapper mapper)
        {
            _gameEventRepository = gameEventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        public IActionResult GetGameEvents()
        {
            var events = _mapper.Map<List<GameEventDto>>(_gameEventRepository.GetGameEvents());

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        [ProducesResponseType(400)]
        public IActionResult GetGameEvent(int eventId)
        {
            if(!_gameEventRepository.GameEventExists(eventId))
                return NotFound();

            var _event = _mapper.Map<GameEventDto>(_gameEventRepository.GetGameEvent(eventId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_event);
        }

        [HttpGet("games/{eventId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGamesByEventId(int eventId)
        {
            if (!_gameEventRepository.GameEventExists(eventId)) 
                return NotFound();
            
            var games = _mapper.Map<List<GameDto>>(_gameEventRepository.GetGamesByEventId(eventId));

            return Ok(games);
        }
    }
}
