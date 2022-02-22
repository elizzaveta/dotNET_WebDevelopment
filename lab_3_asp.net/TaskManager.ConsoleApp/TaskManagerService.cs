using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.ConsoleApp
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;
        private readonly ITeamService _teamService;

        public TaskManagerService(ITaskService taskService, IProjectService projectService,
            IEmployeeService employeeService, ITeamService teamService)
        {
            _taskService = taskService;
            _projectService = projectService;
            _employeeService = employeeService;
            _teamService = teamService;
        }

        public void StartProgram()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~ TaskManager ~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n~~~~~~~~~~~~~~ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Admin\t  2. Employee\t 3. Close Program");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Login as: ");

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            AdminOptions();
                            break;
                        case 2:
                            EmployeeOptions();
                            break;
                        case 3:
                            alive = false;
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }

        private void AdminOptions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~ AdminOptions ~~~~~~~~~~~~~~~~");

            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Create task\t\t 2. Appoint employee for the task");
                Console.WriteLine("3. Get task details\t 4. Exit to Log In");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Choose what to do: ");

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            CreateTask();
                            break;
                        case 2:
                            AppointEmployee();
                            break;
                        case 3:
                            GetTaskDetails();
                            break;
                        case 4:
                            alive = false;
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CreateTask()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~ Create Task: ~~~~~~~~~~~~~~~~");

            try
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Enter task title:");
                var title = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Enter task description:");
                var description = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter time for accomplishment (in hours):");
                var time = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nChoose priority:");
                Console.WriteLine("1. Low\t  2. Medium\t 3. High");
                Console.ForegroundColor = ConsoleColor.Black;
                var priorityOption = Convert.ToInt32(Console.ReadLine());

                string priority;
                switch (priorityOption)
                {
                    case 1:
                        priority = Priority.Low.ToString();
                        break;
                    case 2:
                        priority = Priority.Medium.ToString();
                        break;
                    case 3:
                        priority = Priority.High.ToString();
                        break;
                    default:
                        throw new Exception("No such command was found!");
                }

                var status = Status.NotStarted.ToString();

                var project = ChooseProject();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n1. Choose an employee\t 2. Skip this step for now");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Choose what to do: ");
                var employeeOption = Convert.ToInt32(Console.ReadLine());

                Employee employee;
                switch (employeeOption)
                {
                    case 1:
                        employee = ChooseEmployee(project.Id);
                        break;
                    case 2:
                        employee = null;
                        break;
                    default:
                        throw new Exception("No such command was found!");
                }

                var task = new Task
                {
                    Title = title,
                    Description = description,
                    Time = time,
                    Priority = priority,
                    Status = status,
                    Employee = employee,
                    Project = project
                };
                _taskService.AddNewTask(task);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTask is created.\n");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        private void AppointEmployee()
        {
            var alive = true;
            while (alive)
            {
                try
                {
                    var project = ChooseProject();
                    var tasks = _projectService.GetProjectTasksWithoutEmployee(project.Id);
                    if (!tasks.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nThere is no unappointed tasks.");
                        return;
                    }

                    var task = ChooseTask(tasks);

                    var employee = ChooseEmployee(project.Id);

                    task.Employee = employee;
                    _taskService.UpdateTask(task);


                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nEmployee is appointed to the task.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }

        private Project ChooseProject()
        {
            int id = 0;
            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nChoose project:");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                var projects = _projectService.GetProjects();
                foreach (var project in projects)
                {
                    Console.WriteLine("ID: " + project.Id + " NAME: " + project.Name);
                }

                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter project id: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            return _projectService.GetProject(id);
        }

        private Task ChooseTask(IEnumerable<Task> tasks)
        {
            int taskId = 0;
            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nChoose task:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (var t in tasks)
                {
                    Console.WriteLine("ID: " + t.Id + " TITLE: " + t.Title);
                }

                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter task id: ");
                    taskId = Convert.ToInt32(Console.ReadLine());
                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            return _taskService.GetTask(taskId);
        }

        private Employee ChooseEmployee(int projectId)
        {
            var team = _teamService.GetProjectTeam(projectId);
            var employees = _employeeService.GetTeamEmployees(team.Id);
            int id = 0;
            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nChoose employee:");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                foreach (var e in employees)
                {
                    Console.WriteLine("ID: " + e.Id + " NAME: " + e.FirstName + " " + e.LastName + "\n   ROLE: " +
                                      e.Role + "\n   CURRENT TASKS: " + e.Tasks.Count());
                }

                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter employee id: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            return _employeeService.GetEmployee(id);

        }

        private void GetTaskDetails()
        {
            var alive = true;
            while (alive)
            {
                try
                {
                    var project = ChooseProject();

                    var tasks = _projectService.GetProjectTasks(project.Id);
                    if (!tasks.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nThere is no tasks.");
                        return;
                    }

                    var task = ChooseTask(tasks);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nTask " + task.Id + " details:");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Title: " + task.Title);
                    Console.WriteLine("Description: " + task.Description);
                    Console.WriteLine("Time for accomplishment: " + task.Time);
                    Console.WriteLine("Priority: " + task.Priority);
                    Console.WriteLine("Status: " + task.Status);
                    if (task.Employee != null)
                    {
                        Console.WriteLine($"Employee: {task.Employee.FirstName} " +
                                          $"{task.Employee.LastName} id: {task.Employee.Id}");
                    }
                    else
                    {
                        Console.WriteLine("Employee: None");
                    }

                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void EmployeeOptions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~ EmployeeOptions ~~~~~~~~~~~~~~~~");

            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Get tasks\t 2. Edit task status");
                Console.WriteLine("3. Exit to Log In");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Choose what to do: ");

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            GetEmployeeTasks();
                            break;
                        case 2:
                            EditTaskStatus();
                            break;
                        case 3:
                            alive = false;
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GetEmployeeTasks()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter employee id: ");
            var id = Convert.ToInt32(Console.ReadLine());

            var tasks = _employeeService.GetEmployeeTasks(id);
            var alive = true;
            while (alive)
            {
                try
                {
                    if (!tasks.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nYou have no tasks.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nChoose task:");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    foreach (var t in tasks)
                    {
                        Console.WriteLine("ID: " + t.Id + " TITLE: " + t.Title);
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter task id to view details (or 0 to exit): ");
                    var taskId = Convert.ToInt32(Console.ReadLine());
                    if (taskId == 0) return;
                    var task = _taskService.GetTask(taskId);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nTask " + task.Id + " details:");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Title: " + task.Title);
                    Console.WriteLine("Description: " + task.Description);
                    Console.WriteLine("Time for accomplishment: " + task.Time);
                    Console.WriteLine("Priority: " + task.Priority);
                    Console.WriteLine("Status: " + task.Status);

                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void EditTaskStatus()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter employee id: ");
            var id = Convert.ToInt32(Console.ReadLine());

            var tasks = _employeeService.GetEmployeeTasks(id);
            var alive = true;
            while (alive)
            {
                try
                {
                    if (!tasks.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nYou have no tasks.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nChoose task:");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    foreach (var t in tasks)
                    {
                        Console.WriteLine("ID: " + t.Id + " TITLE: " + t.Title + " STATUS: " + t.Status);
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter task id to edit status: ");
                    var taskId = Convert.ToInt32(Console.ReadLine());
                    var task = _taskService.GetTask(taskId);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nChoose status:");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("1. NotStarted");
                    Console.WriteLine("2. OnExecution");
                    Console.WriteLine("3. Done");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter status number: ");
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            task.Status = Status.NotStarted.ToString();
                            break;
                        case 2:
                            task.Status = Status.OnExecution.ToString();
                            break;
                        case 3:
                            task.Status = Status.Done.ToString();
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }

                    _taskService.UpdateTask(task);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nStatus is updated.");

                    alive = false;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}