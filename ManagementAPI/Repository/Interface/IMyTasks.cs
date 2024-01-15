using ManagementAPI.Model;

namespace ManagementAPI.Repository.Interface
{
    public interface IMyTasks
    {

         public List<MyTask> GetTaskListAsync();
        public MyTask GetTaskListByIdAsync(int id);
        public MyTask AddTaskAsync(MyTask task);
        public MyTask UpdateTaskAsync(Task task);
        public bool DeleteTaskAsync(int id);
    }
}
