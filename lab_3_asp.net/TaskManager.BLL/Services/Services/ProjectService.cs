using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _projectRepository;
        public ProjectService(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }  
        public Project GetProject(int id)
        {
            return _projectRepository.GetById(id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _projectRepository.GetAll();
        }
        
        public IEnumerable<Task> GetProjectTasks(int projectId)
        {
            return _projectRepository.GetById(projectId).Tasks;
        }
        public IEnumerable<Task> GetProjectTasksWithoutEmployee(int projectId)
        {
            return _projectRepository.GetById(projectId).Tasks.Where(t=> t.Employee == null);
        }
    }
}