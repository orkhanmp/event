using BLL.Abstract;
using Entities.DTO.AttendeeDTO;
using Entities.DTO.EventDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService= eventService;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 
            var AllData = _eventService.GetAll().Data;
            return Ok(AllData);
       
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var data = _eventService.Get(id).Data;
            return Ok(data);
        }

        [HttpPost]

        public IActionResult Add(EventAddDTO eventAddDTO)
        {
            _eventService.Add(eventAddDTO);
            return Ok("201");

        }

        [HttpPut]

        public IActionResult Update(EventUpdateDTO eventUpdateDTO)
        {
            _eventService.Update(eventUpdateDTO);
            return Ok("200");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _eventService.Delete(id);
            return Ok("Deleted Successfully");
        }

    }
}
