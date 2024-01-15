using System.ComponentModel.DataAnnotations;

namespace ManagementAPI.Model
{
    public class MyTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title cannot be empty")]
        public string Ttle { get; set; }
        public string Description { get; set; }
        public bool  IsCompleted { get; set; }
    }
}
