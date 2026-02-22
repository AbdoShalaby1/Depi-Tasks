namespace TMS.Models
{
    public class TaskItem
    {
        // will be database generated (identity) by default
        public int Id { get; set; } 
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
