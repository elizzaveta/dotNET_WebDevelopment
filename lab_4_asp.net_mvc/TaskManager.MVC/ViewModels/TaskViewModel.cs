using System.Collections.Generic;
using System.Linq;
using TaskManager.DAL.Models;


namespace TaskManager.MVC.Models
{
    public class TaskModel
    {
        public IEnumerable<Task> Tasks { get; set; }
        // public int Id { get; set; }
        // public string Title { get; set; }
        // public string Description { get; set; }
        // public int Time { get; set; } 
        // public string Priority { get; set; }
        // public string Status { get; set; }
        // public string Project { get; set; }
        // public string Employee { get; set; }

    }

    public class OneTaskModel
    {
        public Task Task { get; set; }
    }
    // public static class TaskExtensions
    // {
    //     public static TaskModel FromContract(this BizzContracts.Task contract)
    //     {
    //         return new TaskModel
    //         {
    //             Id = contract.Id,
    //             Title = contract.Title,
    //             Description = contract.Description,
    //             Time = contract.Time,
    //             Priority = contract.Priority.Name,
    //             Status = contract.Status.Name,
    //             Project = contract.Project.Name,
    //             Employee = contract.Employee.FirstName+" "+contract.Employee.LastName
    //         };
    //     }
    //
    //     public static List<TaskModel> FromContract(this List<BizzContracts.Task> contracts)
    //     {
    //         return contracts.Select(x => x.FromContract()).ToList();
    //     }
    // }
}