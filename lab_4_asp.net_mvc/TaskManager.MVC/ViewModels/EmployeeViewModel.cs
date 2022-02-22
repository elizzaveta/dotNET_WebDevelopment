using TaskManager.DAL.Models;

namespace TaskManager.MVC.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public int CurrentTasks { get; set; }
    }
}