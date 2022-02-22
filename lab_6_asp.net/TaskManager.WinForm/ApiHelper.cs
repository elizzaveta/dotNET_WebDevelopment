using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManager.WEB.DTOs;

namespace TaskManager.WinForm
{
    public class ApiHelper
    {
        private readonly string _baseUrl = "https://localhost:5001";
        private readonly HttpClient _client = new HttpClient();

        /* --- GET --- */
        public async Task<string> ShowAllTasks()
        {
            var response = await _client.GetAsync($"{_baseUrl}/tasks/all");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }
        public async Task<string> GetEmployees()
        {
            var response = await _client.GetAsync($"{_baseUrl}/employees");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }
        public async Task<string> GetEmployeeTasks(string employeeId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/tasks/employee/{employeeId}");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }
        public async Task<string> GetProjects()
        {
            var response = await _client.GetAsync($"{_baseUrl}/projects");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }
        public async Task<string> GetProjectTasks(string projectId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/projects/tasks/project/{projectId}");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        /* --- POST --- */
        public async Task<string> AddNewTask(string task)
        {
            var json = JsonConvert.DeserializeObject<TaskDto>(task);
            var data = JsonConvert.SerializeObject(json);
            var input = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_baseUrl}/tasks/task", input);
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        public async Task<string> UpdateTaskStatus(string task)
        {
            var json = JsonConvert.DeserializeObject<TaskDto>(task);
            var data = JsonConvert.SerializeObject(json);
            var input = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{_baseUrl}/tasks/task", input);
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        /* --- JSON Converter --- */
        public string ShowAsJson(string content)
        {
            var parseJson = JToken.Parse(content);
            return parseJson.ToString(Formatting.Indented);
        }
    }
}
