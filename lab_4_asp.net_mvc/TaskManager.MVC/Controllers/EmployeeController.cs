using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.MVC.Models;
using TaskManager.MVC.ViewModels;

namespace TaskManager.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly ITeamService _teamService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<HomeController> logger
            , ITaskService taskService
            , IProjectService projectService
            , IPriorityService priorityService
            , IStatusService statusService
            , ITeamService teamService
            , IEmployeeService employeeService
        )
        {
            _logger = logger;
            _taskService = taskService;
            _projectService = projectService;
            _priorityService = priorityService;
            _statusService = statusService;
            _teamService = teamService;
            _employeeService = employeeService;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Employees()
        {
            var employees = _employeeService.GetEmployees();
            IEnumerable<EmployeeViewModel> employeesModels = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                employeesModels = employeesModels.Append(new EmployeeViewModel()
                {
                    Employee = employee,
                    CurrentTasks = _employeeService.GetEmployeeTasks(employee.Id).Count()
                });
            }
            return View(employeesModels);
        }
    }
}