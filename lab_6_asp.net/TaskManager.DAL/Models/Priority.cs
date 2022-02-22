using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Models
{
    public class Priority
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }

        // Low, Medium, High
    }
}