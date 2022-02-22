using AutoMapper;
using TaskManager.DAL.Models;
using TaskManager.WEB.DTOs;
using TaskManager.WEB.ViewModels;

namespace TaskManager.WEB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, PostTaskViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Priority, PriorityViewModel>();
            CreateMap<Status, StatusViewModel>();
            CreateMap<Task, GetTaskViewModel>();
            
            

            CreateMap<PostTaskViewModel, TaskDto>();
        }
    }
}