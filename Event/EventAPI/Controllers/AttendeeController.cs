using BLL.Abstract;
using Entities.DTO.AttendeeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllData = _attendeeService.GetAll().Data;
            return Ok(AllData);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var data = _attendeeService.Get(id).Data;
            return Ok(data);
        }

        [HttpPost]

        public IActionResult Add(AttendeeAddDTO attendeeAddDTO)
        { 
            _attendeeService.Add(attendeeAddDTO);
            return Ok("201");
        
        }

        [HttpPut]

        public IActionResult Update(AttendeeUpdateDTO attendeeUpdateDTO)
        {
            _attendeeService.Update(attendeeUpdateDTO);
            return Ok("200");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _attendeeService.Delete(id);
            return Ok("Deleted Successfully");
        }


    }

}
