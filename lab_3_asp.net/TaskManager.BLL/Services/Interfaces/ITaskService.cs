using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> GetTasks();
        Task GetTask(int id);
        void AddNewTask(Task task);
        void UpdateTask(Task task);

    }
}