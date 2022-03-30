namespace TrainingCenter.Core.Models
{
    public class Lesson : BaseModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? CourseId { get; internal set; }        

        public Lesson(string title)
        {
            Title = title;
        }
    }
}
