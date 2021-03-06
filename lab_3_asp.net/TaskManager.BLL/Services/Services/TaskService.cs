using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<Task> _taskRepository;

        public TaskService(IGenericRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<Task> GetTasks()
        {
            return _taskRepository.GetAll();
        }

        public Task GetTask(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void AddNewTask(Task task)
        {
            _taskRepository.Create(task);
        }

        public void UpdateTask(Task task)
        {
            _taskRepository.Update(task);
        }
    }
}