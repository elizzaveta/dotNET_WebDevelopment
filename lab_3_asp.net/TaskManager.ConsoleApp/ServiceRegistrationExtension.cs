using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.BLL.Repositories.Repositories;
using TaskManager.BLL.Services.Interfaces;
using TaskManager.BLL.Services.Services;

namespace TaskManager.ConsoleApp
{
    public class ServiceRegistrationExtension
    {
        private static readonly IConfigurationRoot Configuration = 
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        
        public static ServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddSingleton<ITaskService, TaskService>()
                .AddSingleton<IProjectService, ProjectService>()
                .AddSingleton<IEmployeeService, EmployeeService>()
                .AddSingleton<ITeamService, TeamService>()
                .AddSingleton<ITaskManagerService, TaskManagerService>()
                .AddDbContext<DAL.ApplicationContext>(options => options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();
        }
    }
}