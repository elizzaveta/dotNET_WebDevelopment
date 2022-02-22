using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.MVC.Models;
using TaskManager.MVC.ViewModels;

namespace TaskManager.MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<HomeController> logger
            , ITaskService taskService
            , IProjectService projectService
        )
        {
            _logger = logger;
            _taskService = taskService;
            _projectService = projectService;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Projects()
        {
            var projects = new ProjectViewModel
            {
                Projects = _projectService.GetProjects()
            };
            return View(projects);
        }
    }
}