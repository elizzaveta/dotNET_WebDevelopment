using System.Collections.Generic;

namespace TaskManager.WEB.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public ProjectViewModel Project{ get; set; }
        public IEnumerable<GetTaskViewModel> Tasks { get; set; }
    }
}