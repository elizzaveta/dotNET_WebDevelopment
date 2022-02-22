using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface ITeamService
    {
        Team GetProjectTeam(int projectId);
        IEnumerable<Employee> GetTeamEmployeesOfProject(int projectId);
    }
}