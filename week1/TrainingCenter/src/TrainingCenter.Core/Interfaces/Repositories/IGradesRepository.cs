using TrainingCenter.Core.Models;

namespace TrainingCenter.Core.Interfaces.Repositories
{
    /// <summary>
    /// Defines persistence logic for grades
    /// </summary>
    public interface IGradesRepository : IRepository<Grade>
    {
        /// <summary>
        /// Returns student's lesson grades for the course.        
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>        
        IEnumerable<Grade> GetStudentLessonGrades(int studentId, int courseId);
    }
}
