using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;
using TaskManager.WEB.DTOs;
using TaskManager.WEB.ViewModels;

namespace TaskManager.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        
        [HttpGet("task/{id}")]
        public GetTaskViewModel GetTask(int id)
        {
            var task = _taskService.GetTask(id);
            return _mapper.Map<GetTaskViewModel>(task);
        }
        [HttpGet("all")]
        public IEnumerable<GetTaskViewModel> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return _mapper.Map<IEnumerable<GetTaskViewModel>>(tasks);
        }
        [HttpGet("project/{id}")]
        public IEnumerable<GetTaskViewModel> GetTasksOfProject(int id)
        {
            var tasks =  _taskService.GetTasksOfProject(id);
            return _mapper.Map<IEnumerable<GetTaskViewModel>>(tasks);
        }
        
        [HttpGet("employee/{id}")]
        public IEnumerable<GetTaskViewModel> GetActiveTasksOfEmployee(int id)
        {
            var tasks = _taskService.GetActiveTasksOfEmployee(id);
            return _mapper.Map<IEnumerable<GetTaskViewModel>>(tasks);
        }
        
        [HttpPost("task")]
        public void PostNewTask([FromBody] PostTaskViewModel postTask)
        {
            var taskToAdd = _mapper.Map<TaskDto>(postTask);
            _taskService.AddNewTask(taskToAdd);
        }
        [HttpPut("task")]
        public void PutNewTask([FromBody] PostTaskViewModel postTask)
        {
            var taskToUpdate = _mapper.Map<TaskDto>(postTask);
            _taskService.UpdateTask(taskToUpdate);
        }
    }
} 