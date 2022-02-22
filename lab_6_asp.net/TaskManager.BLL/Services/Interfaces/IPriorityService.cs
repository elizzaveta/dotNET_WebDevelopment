
using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface IPriorityService
    {
        IEnumerable<Priority> GetPriorities();
        Priority GetPriorityById(int id);

    }
}