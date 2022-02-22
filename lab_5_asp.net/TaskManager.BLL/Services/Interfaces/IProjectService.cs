using System.Collections;
using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        Project GetProject(int id);
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetActiveProjects();
        IEnumerable<Task> GetProjectTasks(int projectId);
    }
}