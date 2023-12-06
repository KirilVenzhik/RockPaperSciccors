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
    public class GameEventController : Controller
    {
        private readonly IGameEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GameEventController(IGameEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        public IActionResult GetGameEvents()
        {
            var events = _mapper.Map<List<GameEventDto>>(_eventRepository.GetGameEvents());

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        [ProducesResponseType(400)]
        public IActionResult GetGameEvent(int eventId)
        {
            if(!_eventRepository.GameEventExists(eventId))
                return NotFound();

            var _event = _mapper.Map<GameEventDto>(_eventRepository.GetGameEvent(eventId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_event);
        }

        [HttpGet("games/{eventId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGamesByEventId(int eventId)
        {
            if (!_eventRepository.GameEventExists(eventId)) 
                return NotFound();
            
            var games = _mapper.Map<List<GameDto>>(_eventRepository.GetGamesByEventId(eventId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(games);
        }

        [HttpGet("event/{gameId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GameEvent>))]
        [ProducesResponseType(400)]
        public IActionResult GetEventByGameId(int gameId)
        {
            var _event = _mapper.Map<GameEventDto>(_eventRepository.GetEventByGameId(gameId));

            if (_event == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_event);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] GameEventDto gameEventCreate)
        {
            if (gameEventCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameEventMap = _mapper.Map<GameEvent>(gameEventCreate);

            if (!_eventRepository.CreateGameEvent(gameEventMap))
            {
                ModelState.AddModelError("", "Someting went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{eventId}")]
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(int eventId, [FromBody] GameEventDto updatedEvent)
        {
            if (updatedEvent == null || !_eventRepository.GameEventExists(eventId) || !ModelState.IsValid)
                return BadRequest(ModelState);

            var eventMap = _mapper.Map<GameEvent>(updatedEvent);

            if (!_eventRepository.UpdateEvent(eventId, eventMap))
            {
                ModelState.AddModelError("", "Something went wrong updating game event");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEvent(int eventId)
        {
            if (!_eventRepository.GameEventExists(eventId))
            {
                return NotFound();
            }

            var eventToDelete = _eventRepository.GetGameEvent(eventId);

            if(_eventRepository.GetGamesByEventId(eventId).Any())
            {
                ModelState.AddModelError("", "Unable to delete while games with this event is in progress.");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_eventRepository.DeleteEvent(eventToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
