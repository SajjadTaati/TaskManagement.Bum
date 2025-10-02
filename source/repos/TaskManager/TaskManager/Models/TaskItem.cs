using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا عنوان تسک را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات تسک را وارد کنید")]
        [MaxLength(1000)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime CreationDaye { get; set; } = DateTime.Now;


        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
