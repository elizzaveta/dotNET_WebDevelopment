namespace TaskManager.WinForm
{
    partial class TaskManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_get_all_tasks = new System.Windows.Forms.Button();
            this.text_result = new System.Windows.Forms.RichTextBox();
            this.btn_get_employees = new System.Windows.Forms.Button();
            this.text_employee_id = new System.Windows.Forms.TextBox();
            this.btn_get_employee_tasks = new System.Windows.Forms.Button();
            this.btn_get_projects = new System.Windows.Forms.Button();
            this.text_project_id = new System.Windows.Forms.TextBox();
            this.btn_get_project_tasks = new System.Windows.Forms.Button();
            this.btn_add_task = new System.Windows.Forms.Button();
            this.input_add_task = new System.Windows.Forms.RichTextBox();
            this.btn_update_task_status = new System.Windows.Forms.Button();
            this.input_update_task_status = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_get_all_tasks
            // 
            this.btn_get_all_tasks.Location = new System.Drawing.Point(33, 28);
            this.btn_get_all_tasks.Name = "btn_get_all_tasks";
            this.btn_get_all_tasks.Size = new System.Drawing.Size(445, 29);
            this.btn_get_all_tasks.TabIndex = 0;
            this.btn_get_all_tasks.Text = "Get All Tasks";
            this.btn_get_all_tasks.UseVisualStyleBackColor = true;
            this.btn_get_all_tasks.Click += new System.EventHandler(this.btn_get_all_tasks_Click);
            // 
            // text_result
            // 
            this.text_result.Location = new System.Drawing.Point(33, 203);
            this.text_result.Name = "text_result";
            this.text_result.Size = new System.Drawing.Size(445, 389);
            this.text_result.TabIndex = 1;
            this.text_result.Text = "";
            // 
            // btn_get_employees
            // 
            this.btn_get_employees.Location = new System.Drawing.Point(33, 63);
            this.btn_get_employees.Name = "btn_get_employees";
            this.btn_get_employees.Size = new System.Drawing.Size(445, 29);
            this.btn_get_employees.TabIndex = 2;
            this.btn_get_employees.Text = "Get Employees";
            this.btn_get_employees.UseVisualStyleBackColor = true;
            this.btn_get_employees.Click += new System.EventHandler(this.btn_get_employees_Click);
            // 
            // text_employee_id
            // 
            this.text_employee_id.Location = new System.Drawing.Point(33, 98);
            this.text_employee_id.Name = "text_employee_id";
            this.text_employee_id.Size = new System.Drawing.Size(93, 27);
            this.text_employee_id.TabIndex = 3;
            // 
            // btn_get_employee_tasks
            // 
            this.btn_get_employee_tasks.Location = new System.Drawing.Point(132, 98);
            this.btn_get_employee_tasks.Name = "btn_get_employee_tasks";
            this.btn_get_employee_tasks.Size = new System.Drawing.Size(346, 29);
            this.btn_get_employee_tasks.TabIndex = 4;
            this.btn_get_employee_tasks.Text = "Get Employee Tasks";
            this.btn_get_employee_tasks.UseVisualStyleBackColor = true;
            this.btn_get_employee_tasks.Click += new System.EventHandler(this.btn_get_employee_tasks_Click);
            // 
            // btn_get_projects
            // 
            this.btn_get_projects.Location = new System.Drawing.Point(33, 133);
            this.btn_get_projects.Name = "btn_get_projects";
            this.btn_get_projects.Size = new System.Drawing.Size(445, 29);
            this.btn_get_projects.TabIndex = 6;
            this.btn_get_projects.Text = "Get Projects";
            this.btn_get_projects.UseVisualStyleBackColor = true;
            this.btn_get_projects.Click += new System.EventHandler(this.btn_get_projects_Click);
            // 
            // text_project_id
            // 
            this.text_project_id.Location = new System.Drawing.Point(33, 168);
            this.text_project_id.Name = "text_project_id";
            this.text_project_id.Size = new System.Drawing.Size(92, 27);
            this.text_project_id.TabIndex = 8;
            // 
            // btn_get_project_tasks
            // 
            this.btn_get_project_tasks.Location = new System.Drawing.Point(132, 168);
            this.btn_get_project_tasks.Name = "btn_get_project_tasks";
            this.btn_get_project_tasks.Size = new System.Drawing.Size(346, 29);
            this.btn_get_project_tasks.TabIndex = 9;
            this.btn_get_project_tasks.Text = "Get Project Tasks";
            this.btn_get_project_tasks.UseVisualStyleBackColor = true;
            this.btn_get_project_tasks.Click += new System.EventHandler(this.btn_get_project_tasks_Click);
            // 
            // btn_add_task
            // 
            this.btn_add_task.Location = new System.Drawing.Point(498, 28);
            this.btn_add_task.Name = "btn_add_task";
            this.btn_add_task.Size = new System.Drawing.Size(242, 29);
            this.btn_add_task.TabIndex = 10;
            this.btn_add_task.Text = "Add Task";
            this.btn_add_task.UseVisualStyleBackColor = true;
            this.btn_add_task.Click += new System.EventHandler(this.btn_add_task_Click);
            // 
            // input_add_task
            // 
            this.input_add_task.Location = new System.Drawing.Point(498, 63);
            this.input_add_task.Name = "input_add_task";
            this.input_add_task.Size = new System.Drawing.Size(242, 241);
            this.input_add_task.TabIndex = 11;
            this.input_add_task.Text = "";
            // 
            // btn_update_task_status
            // 
            this.btn_update_task_status.Location = new System.Drawing.Point(498, 316);
            this.btn_update_task_status.Name = "btn_update_task_status";
            this.btn_update_task_status.Size = new System.Drawing.Size(242, 29);
            this.btn_update_task_status.TabIndex = 12;
            this.btn_update_task_status.Text = "Update Task Status";
            this.btn_update_task_status.UseVisualStyleBackColor = true;
            this.btn_update_task_status.Click += new System.EventHandler(this.btn_update_task_status_Click);
            // 
            // input_update_task_status
            // 
            this.input_update_task_status.Location = new System.Drawing.Point(498, 351);
            this.input_update_task_status.Name = "input_update_task_status";
            this.input_update_task_status.Size = new System.Drawing.Size(242, 241);
            this.input_update_task_status.TabIndex = 13;
            this.input_update_task_status.Text = "";
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 604);
            this.Controls.Add(this.input_update_task_status);
            this.Controls.Add(this.btn_update_task_status);
            this.Controls.Add(this.input_add_task);
            this.Controls.Add(this.btn_add_task);
            this.Controls.Add(this.btn_get_project_tasks);
            this.Controls.Add(this.text_project_id);
            this.Controls.Add(this.btn_get_projects);
            this.Controls.Add(this.btn_get_employee_tasks);
            this.Controls.Add(this.text_employee_id);
            this.Controls.Add(this.btn_get_employees);
            this.Controls.Add(this.text_result);
            this.Controls.Add(this.btn_get_all_tasks);
            this.Name = "TaskManager";
            this.Text = "TaskManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_get_all_tasks;
        private System.Windows.Forms.RichTextBox text_result;
        private System.Windows.Forms.Button btn_get_employees;
        private System.Windows.Forms.TextBox text_employee_id;
        private System.Windows.Forms.Button btn_get_employee_tasks;
        private System.Windows.Forms.Button btn_get_projects;
        private System.Windows.Forms.TextBox text_project_id;
        private System.Windows.Forms.Button btn_get_project_tasks;
        private System.Windows.Forms.Button btn_add_task;
        private System.Windows.Forms.RichTextBox input_add_task;
        private System.Windows.Forms.Button btn_update_task_status;
        private System.Windows.Forms.RichTextBox input_update_task_status;
    }
}