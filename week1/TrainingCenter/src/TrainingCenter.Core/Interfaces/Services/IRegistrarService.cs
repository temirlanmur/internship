using TrainingCenter.Core.DTOs;

namespace TrainingCenter.Core.Interfaces.Services
{
    public interface IRegistrarService
    {
        void GiveStudentLessonGrade(CreateLessonGradeDTO dto);
        decimal CalculateStudentFinalScore(int studentId, int courseId);
    }
}
