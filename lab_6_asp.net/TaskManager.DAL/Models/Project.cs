using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int IsActive { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

    }
}