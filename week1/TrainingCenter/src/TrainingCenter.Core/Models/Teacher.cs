namespace TrainingCenter.Core.Models
{
    public class Teacher : BaseModel
    {
        public string FullName { get; set; }        
        public List<Course> Courses { get; internal set; } = new();

        public Teacher(string fullName)
        {
            FullName = fullName;
        }
    }
}
