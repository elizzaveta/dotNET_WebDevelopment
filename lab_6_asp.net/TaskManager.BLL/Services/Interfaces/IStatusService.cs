using System.Collections.Generic;
using Microsoft.Net.Http.Headers;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetStatuses();
        Status GetStatusById(int id);
    }
}