using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;
using TaskManager.WEB.DTOs;

namespace TaskManager.BLL.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<Task, int> _taskRepository;
        private readonly IGenericRepository<Employee, int> _employeeRepository;
        private readonly IGenericRepository<Status, int> _statusRepository;
        private readonly IGenericRepository<Priority, int> _priorityRepository;

        public TaskService(IGenericRepository<Task, int> taskRepository, IGenericRepository<Employee, int> employeeRepository, IGenericRepository<Status, int> statusRepository, IGenericRepository<Priority, int> priorityRepository)
        {
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
            _statusRepository = statusRepository;
            _priorityRepository = priorityRepository;
        }
        public IEnumerable<Task> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }
        public Task GetTask(int taskId)
        {
            return _taskRepository.GetById(taskId);
        }
        public IEnumerable<Task> GetTasksOfProject(int projectId)
        {
            return _taskRepository.GetAll().AsQueryable()
                .Where(task => task.Employee.Project.Id == projectId);
        }
        public IEnumerable<Task> GetActiveTasksOfEmployee(int employeeId)
        {
            return _taskRepository.GetAll().AsQueryable()
                .Where(task => task.Employee.Project.Id == employeeId && task.Status.Id != 3);
        }
        
        public void AddNewTask(TaskDto task)
        {
            var employee = _employeeRepository.GetById(task.EmployeeId);
            var priority = _priorityRepository.GetById(task.PriorityId);
            var status = _statusRepository.GetById(task.StatusId);

            var taskToAdd = new Task
            {
                Title = task.Title,
                Description = task.Description,
                Time = task.Time,
                Employee = employee,
                Priority = priority,
                Status = status
            };
            _taskRepository.Create(taskToAdd);
            _taskRepository.Save();
        }
        public void UpdateTask(TaskDto task)
        {
            var employee = _employeeRepository.GetById(task.EmployeeId);
            var priority = _priorityRepository.GetById(task.PriorityId);
            var status = _statusRepository.GetById(task.StatusId);

            var taskToUpdate = new Task
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Time = task.Time,
                Employee = employee,
                Priority = priority,
                Status = status
            };
            _taskRepository.Update(taskToUpdate);
            _taskRepository.Save();
        }
    }
}