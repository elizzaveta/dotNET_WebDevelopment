using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee, int> _employeeRepository;
        
        public EmployeeService(IGenericRepository<Employee, int> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }  
        
        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll();
        }
        public IEnumerable<Employee> GetTeamEmployees(int teamId)
        {
            var employees = _employeeRepository.GetAll();
            return employees.Where(e => e.Team.Id == teamId);
        }
        
        public IEnumerable<Task> GetEmployeeTasks(int employeeId)
        {
            return _employeeRepository.GetById(employeeId).Tasks
                .Where(task=>task.Status.Name != "Done");
        }
    }
}