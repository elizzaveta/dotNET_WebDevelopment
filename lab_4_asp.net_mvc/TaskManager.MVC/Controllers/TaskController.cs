using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;
using TaskManager.MVC.Models;
using TaskManager.MVC.ViewModels;

namespace TaskManager.MVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly ITeamService _teamService;
        private readonly IEmployeeService _employeeService;

        public TaskController(ILogger<HomeController> logger
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            var taskModel = new TaskModel()
            {
                Tasks = _taskService.GetTasks()
            };
            return View(taskModel);
        }

        public IActionResult TaskDetails(int id)
        {
            var task = new OneTaskModel
            {
                Task = _taskService.GetTask(id)
            };
            return View(task);
        }

        public IActionResult ProjectTasks(int id)
        {
            var tasks = new TaskModel
            {
                Tasks = _taskService.GetTasksOfProject(id)
            };
            return View(tasks);
        }
        public IActionResult EmployeeTasks(int id)
        {
            var tasks = new TaskModel
            {
                Tasks = _employeeService.GetEmployeeTasks(id)
            };
            return View(tasks);
        }
        public IActionResult UpdateTaskStatus(int id)
        {
            var task = new OneTaskModel
            {
                Task = _taskService.GetTask(id)
            };
            return View(task);
        }

        public IActionResult NewTask()
        {
            IEnumerable<OneProjectViewModel> projectModels = new List<OneProjectViewModel>();
            var projects = _projectService.GetProjects();
            foreach (var project in projects)
            {
                IEnumerable<Employee> employees = _teamService.GetTeamEmployeesOfProject(project.Id);
                IEnumerable<EmployeeViewModel> employeeModels = new List<EmployeeViewModel>();
                foreach (var employee in employees)
                {
                    employeeModels = employeeModels.Append(new EmployeeViewModel
                    {
                        Employee = employee,
                        CurrentTasks = _employeeService.GetEmployeeTasks(employee.Id).Count()
                    });
                }
                projectModels = projectModels.Append(new OneProjectViewModel
                {
                    Project = project,
                    EmployeeViewModels = employeeModels
                });
            }

            return View(projectModels); //todo: how to give project list and employee list??
        }

        

        [HttpPost]
        public IActionResult NewTask(string title, string description,
            int timeForAccomplishment, int priority, int project, int employee)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                Time = timeForAccomplishment,
                Priority = _priorityService.GetPriorityById(priority),
                Status = _statusService.GetStatusById(1),
                Project = _projectService.GetProject(project),
                Employee = _employeeService.GetEmployee(employee)
            };
            _taskService.AddNewTask(task);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult PutTaskStatus(int taskId, int status)
        {
            var a = 0;

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}