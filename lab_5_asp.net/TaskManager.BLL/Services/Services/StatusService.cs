using System.Collections.Generic;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class StatusService : IStatusService
    {
        private readonly IGenericRepository<Status, int> _statusRepository;

        public StatusService(IGenericRepository<Status, int> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _statusRepository.GetAll();
        } 
        public Status GetStatusById(int id)
        {
            return _statusRepository.GetById(id);
        } 
    }
}