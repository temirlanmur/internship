namespace TrainingCenter.Core.Models
{
    public class Student : BaseModel
    {
        public string FullName { get; set; }        
        public List<Course> Courses { get; internal set; } = new();

        public Student(string fullName)
        {
            FullName = fullName;
        }
    }
}
