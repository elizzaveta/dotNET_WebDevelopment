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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployee(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }
        // public IEnumerable<Task> GetEmployeeActiveTasks(int employeeId)
        // {
        //     var employeeTasks = _employeeRepository.GetById(employeeId).Tasks;
        //     return employeeTasks.Where(task => task.Status.Name != "Done");
        // }
    }
}