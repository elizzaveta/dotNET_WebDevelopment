using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string FirstName { get; set; }
        [Required, MaxLength(200)]
        public string LastName { get; set; }
        [Required, MaxLength(200)]
        public string Role { get; set; }
        public virtual Project Project{ get; set; }
        public virtual IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}