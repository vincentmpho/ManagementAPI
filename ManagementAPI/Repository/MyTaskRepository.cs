using ManagementAPI.Data;
using ManagementAPI.Model;
using ManagementAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ManagementAPI.Repository
{
    public class MyTaskRepository : IMyTasks
    {
        private readonly TaskDbContext _taskDbContext;

        public MyTaskRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public MyTask AddTaskAsync(MyTask task)
        {
            var result = _taskDbContext.myTasks.Add(task);
            _taskDbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteTaskAsync(int id)
        {
            var filteredData = _taskDbContext.myTasks.Where(x => x.Id == id).FirstOrDefault();
            var result = _taskDbContext.Remove(filteredData);
            _taskDbContext.SaveChanges();
            return result != null ? true : false;
        }

        public List<MyTask> GetTaskListAsync()
        {
            return _taskDbContext.myTasks.ToList();
        }

        public MyTask GetTaskListByIdAsync(int id)
        {
            return _taskDbContext.myTasks.Where(x =>x.Id == id).FirstOrDefault();
        }

        public MyTask UpdateTaskAsync(Task task)
        {
            var result = _taskDbContext.myTasks.Update(Task);
            _taskDbContext.SaveChanges();
            return result.Entity;
        }
    }
}
