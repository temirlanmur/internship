namespace TrainingCenter.Core.DTOs
{
    public class CreateLessonGradeDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int LessonId { get; set; }
        public decimal Grade { get; set; }
    }
}
