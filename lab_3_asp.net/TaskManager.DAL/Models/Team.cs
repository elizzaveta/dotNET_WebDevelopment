using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Name { get; set; }
        
        public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public virtual Project Project { get; set; }
        
    }
}