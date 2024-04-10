using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Models;
using WebApplicationApi.Services;

namespace WebApplicationApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : ControllerBase
    {
        ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Task task)
        {
            taskService.Save(task);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Models.Task task)
        {
            taskService.Update(id, task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.Delete(id);
            return Ok();
        }


    }
}
