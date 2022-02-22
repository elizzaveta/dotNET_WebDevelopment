using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.MVC.ViewModels
{
    public class ProjectViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<EmployeeViewModel> EmployeeViewModels { get; set; }
    }

    public class OneProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<EmployeeViewModel> EmployeeViewModels { get; set; }
    }
}