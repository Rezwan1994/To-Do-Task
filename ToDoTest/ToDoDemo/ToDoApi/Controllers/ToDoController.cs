using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.BusinessObject;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _service;
        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost("createtask")]
        public async Task<ActionResult<bool>> CreateTask(Model.Task task)
       {
            try
            {
                if (task != null)
                {
                    task.Created = DateTime.Now;
                    _service.AddTask(task);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
       }

        [HttpPost("edittask")]
        public async Task<ActionResult<bool>> EditTask(TaskEditModel task)
        {
            try
            {
                Model.Task toDoTask = new Model.Task();
                toDoTask = _service.GetById(task.id);
                toDoTask.isCompleted = task.isCompleted;
                  
                _service.UpdateTask(toDoTask);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        [Authorize]
        [HttpPost("deletetask")]
        public async Task<ActionResult<bool>> DeleteTask(TaskEditModel task)
        {
            try
            {
                _service.DeleteTask(task.id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       

        [HttpGet("getalltask")]
        public IList<Model.Task> GetAllTask(int id)
        {     
            
            return _service.GetAll(); ;
        }
    }
}
