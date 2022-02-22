using System.Collections.Generic;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly IGenericRepository<Priority, int> _priorityRepository;

        public PriorityService(IGenericRepository<Priority, int> priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public IEnumerable<Priority> GetPriorities()
        {
            return _priorityRepository.GetAll();
        } 
        public Priority GetPriorityById(int id)
        {
            return _priorityRepository.GetById(id);
        }   
    }
}