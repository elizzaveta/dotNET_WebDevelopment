using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;
using TaskManager.WEB.ViewModels;

namespace TaskManager.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        }
        [HttpGet("employee/{id}")]
        public EmployeeViewModel GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}