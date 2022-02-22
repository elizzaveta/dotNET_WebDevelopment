using System.Collections;
using System.Collections.Generic;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetTeamEmployees(int teamId);
        IEnumerable<Task> GetEmployeeTasks(int employeeId);
    }
}