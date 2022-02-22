using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager.WinForm
{
    public partial class TaskManager : Form
    {
        private readonly ApiHelper _apiHelper = new ApiHelper();

        public TaskManager()
        {
            InitializeComponent();
        }

        /* --- GET --- */
        private async void btn_get_all_tasks_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.ShowAllTasks();
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_get_employee_tasks_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetEmployeeTasks(text_employee_id.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_get_employees_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetEmployees();
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_get_projects_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetProjects();
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_get_project_tasks_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetProjectTasks(text_project_id.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_add_task_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.AddNewTask(input_add_task.Text);
            text_result.Text = "Task is added";
            // text_result.Text = _apiHelper.ShowAsJson(response);
        }
        private async void btn_update_task_status_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.UpdateTaskStatus(input_update_task_status.Text);
            text_result.Text = "Task status is updated";
            // text_result.Text = _apiHelper.ShowAsJson(response);
        }



        //private async void btn_meal_ingredients_Click(object sender, EventArgs e)
        //{
        //    var response = await _apiHelper.GetMealIngredients(text_meal_id.Text);
        //    text_result.Text = _apiHelper.ShowAsJson(response);
        //}
        ///* --- POST --- */
        //private async void btn_new_meal_Click(object sender, EventArgs e)
        //{
        //    var response = await _apiHelper.AddNewMeal(text_meal_name.Text, text_new_meal.Text);
        //    text_result.Text = _apiHelper.ShowAsJson(response);
        //}
    }
}