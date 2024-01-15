using ManagementAPI.Model;
using ManagementAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMyTasks _myTasks;

        public TasksController(IMyTasks myTasks)
        {
            _myTasks = myTasks;
        }

        [HttpGet("tasksList")]
        public IEnumerable<MyTask> TasksList()
        {
            var tasksList = _myTasks.GetTaskListAsync();
            return tasksList;
        }
        [HttpGet("getproductbyid")]
        public MyTask GetTaskById(int Id)
        {
            return _myTasks.GetTaskListByIdAsync(Id);
        }
        [HttpPost("addtask")]
        public MyTask AddTask(MyTask task)
        {
            return _myTasks.AddTaskAsync(task);
        }
        [HttpPut("updatetask")]
        public MyTask UpdateTask(MyTask task)
        {
            return _myTasks.UpdateTaskAsync(task);
        }
        [HttpDelete("deletetask")]
        public bool DeleteTask(int Id)
        {
            return _myTasks.DeleteTaskAsync(Id);
        }
    }
}
