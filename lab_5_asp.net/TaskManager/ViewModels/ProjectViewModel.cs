using System.Collections.Generic;

namespace TaskManager.WEB.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}