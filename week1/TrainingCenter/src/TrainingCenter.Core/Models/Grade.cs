using TrainingCenter.Core.Models.Enums;

namespace TrainingCenter.Core.Models
{
    public class Grade : BaseModel
    {
        public GradeType GradeType { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? LessonId { get; set; }
        public decimal GradeValue { get; set; }
    }
}
