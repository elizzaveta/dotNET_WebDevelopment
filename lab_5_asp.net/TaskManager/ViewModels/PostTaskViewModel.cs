namespace TaskManager.WEB.ViewModels
{
    public class PostTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int EmployeeId { get; set; }
    }
}