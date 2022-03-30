namespace TrainingCenter.Core.Models
{
    public class Course : BaseModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Teacher? Teacher { get; internal set; }        
        public List<Lesson> Lessons { get; internal set; } = new();

        public Course(string title)
        {
            Title = title;
        }
    }
}
