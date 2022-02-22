using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = ServiceRegistrationExtension.RegisterServices();
            var taskService = serviceProvider.GetRequiredService<ITaskManagerService>();

            taskService.StartProgram();
        }
    }

}