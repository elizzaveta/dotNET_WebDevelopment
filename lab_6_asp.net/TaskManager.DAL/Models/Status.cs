using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        
        // NotStarted, OnExecution, Done
    }
}