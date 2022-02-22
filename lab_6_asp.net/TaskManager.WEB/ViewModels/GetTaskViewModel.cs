namespace TaskManager.WEB.ViewModels
{
    public class GetTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; } 
        public PriorityViewModel Priority { get; set; }
        public StatusViewModel Status { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }

}