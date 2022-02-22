using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;
using TaskManager.WEB.ViewModels;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public ProjectsController( IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            var projects = _projectService.GetProjects();
            return _mapper.Map<IEnumerable<ProjectViewModel>>(projects);
        }
        [HttpGet("project/{id}")]
        public ProjectViewModel GetProject(int id)
        {
            var project = _projectService.GetProject(id);
            return _mapper.Map<ProjectViewModel>(project);
        }
        [HttpGet("tasks/project/{id}")]
        public IEnumerable<GetTaskViewModel> GetAllProjectTasks(int id)
        {
            var tasks = _projectService.GetProjectTasks(id);
            return _mapper.Map<IEnumerable<GetTaskViewModel>>(tasks);
        }
    }
}