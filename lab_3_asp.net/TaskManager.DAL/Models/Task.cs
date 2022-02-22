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
        public int Time { get; set; }  // ?? type?
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
    }

}