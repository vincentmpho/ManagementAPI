using ManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<MyTask> myTasks { get; set; }
    }
}
