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
        private readonly IGenericRepository<Project, int> _projectRepository;
        public ProjectService(IGenericRepository<Project, int> projectRepository)
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
        public IEnumerable<Project> GetActiveProjects()
        {
            return _projectRepository.GetAll().Where(project=> project.IsActive==1);
        }
        public IEnumerable<Task> GetProjectTasks(int projectId)
        {
            var employees = _projectRepository.GetById(projectId).Employees;
            var a =  employees.Select(employee => employee.Tasks);
            foreach(var ieTasks in a)
            {
                foreach(var task in ieTasks)
                {
                    yield return task;
                }
            }
        }
    }
}