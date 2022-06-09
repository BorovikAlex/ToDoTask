using Microsoft.AspNetCore.Mvc;
using ToDoTask.Logic.DTOModels;
using ToDoTask.Logic.IServices;

namespace ToDoTaskWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        [HttpGet, Route("gettodos")]
        public async Task<IActionResult> GetToDos()
        {
            var toDosList = await _service.GetToDos();
            return Ok(toDosList);
        }

        [HttpGet, Route("gettododetails")]
        public async Task<IActionResult> GetToDoDetails([FromQuery] int id)
        {
            var toDosList = await _service.GetToDoDetails(id);
            return Ok(toDosList);
        }


        [HttpPost, Route("addtodo")]
        public async Task<IActionResult> AddToDo([FromBody] ToDoDTO toDoDTO)
        {
            var newToDo = await _service.CreateToDo(toDoDTO);

            return Ok(newToDo);
        }

        [HttpPut, Route("edittodo")]
        public async Task<IActionResult> EditToDo([FromBody] ToDoDTO toDoDTO)
        {
            var _toDo = await _service.EditToDo(toDoDTO);

            return Ok(_toDo);
        }

        [HttpGet, Route("deletetodo")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var toDo = await _service.DeleteToDo(id);
            return Ok(toDo);
        }
    }
}

