using System.Linq;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class TeamService:ITeamService
    {
        private readonly IGenericRepository<Team> _teamRepository;
        public TeamService(IGenericRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        } 
        public Team GetProjectTeam(int projectId)
        {
            var teams = _teamRepository.GetAll();
            return teams.FirstOrDefault(t => t.Project.Id == projectId);
        }
    }
}