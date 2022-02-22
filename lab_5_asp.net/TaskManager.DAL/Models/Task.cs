using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }
        [Required, MaxLength(200)]
        public int Time { get; set; } 
        [Required]
        public virtual Priority Priority { get; set; }
        [Required]
        public virtual Status Status { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
    }

}