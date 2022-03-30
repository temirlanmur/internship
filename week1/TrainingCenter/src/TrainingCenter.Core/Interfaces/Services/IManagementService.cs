namespace TrainingCenter.Core.Interfaces.Services
{
    public interface IManagementService
    {
        void AssignTeacherToCourse(int courseId, int teacherId);
        void AssignStudentToCourse(int courseId, int studentId);
        void AddLessonToCourse(int courseId, int lessonId);
    }
}
