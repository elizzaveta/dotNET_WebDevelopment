using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface ITeamService
    {
        Team GetProjectTeam(int projectId);
    }
}