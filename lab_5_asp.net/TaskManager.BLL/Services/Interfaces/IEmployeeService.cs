using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int employeeId);
        // IEnumerable<Task> GetEmployeeActiveTasks(int employeeId);
    }
}