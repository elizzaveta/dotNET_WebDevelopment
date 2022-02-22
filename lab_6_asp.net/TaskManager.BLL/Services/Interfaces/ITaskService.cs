using System.Collections.Generic;
using TaskManager.DAL.Models;
using TaskManager.WEB.DTOs;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTask(int id);
        IEnumerable<Task> GetTasksOfProject(int id);
        IEnumerable<Task> GetActiveTasksOfEmployee(int employeeId);
        void AddNewTask(TaskDto task);
        void UpdateTask(TaskDto task);
    }
}