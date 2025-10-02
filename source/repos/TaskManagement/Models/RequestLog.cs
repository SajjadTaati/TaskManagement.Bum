using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class RequestLog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Method { get; set; }
        public string Controller { get; set; }

        [MaxLength(200)]
        public string Path { get; set; }   

        public string UserId { get; set; }
        public string Ip { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
