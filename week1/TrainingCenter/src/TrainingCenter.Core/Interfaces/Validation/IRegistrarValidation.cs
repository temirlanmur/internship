using TrainingCenter.Core.DTOs;

namespace TrainingCenter.Core.Interfaces.Validation
{
    public interface IRegistrarValidation
    {
        /// <summary>
        /// Validates data against database
        /// (checks the existence of respective Student, Course, and Lesson entities,
        /// as well as relationships between them).
        /// Throws exception, if validation fails
        /// </summary>
        /// <param name="dto"></param>
        /// <exeption cref="ArgumentException"></exeption>
        void ValidateCreateLessonGradeDTO(CreateLessonGradeDTO dto);

        /// <summary>
        /// Checks that the student is registered for the course.
        /// Throws exception, if the student is not found in db, or is not registered for the course.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <exeption cref="ArgumentException"></exeption>
        void ValidateStudentIsRegisteredForTheCourse(int studentId, int courseId);
    }
}
