using TrainingCenter.Core.DTOs;
using TrainingCenter.Core.Interfaces.Repositories;
using TrainingCenter.Core.Interfaces.Validation;

namespace TrainingCenter.Core.Validation
{
    public class RegistrarValidation : IRegistrarValidation
    {                
        private readonly IStudentsRepository _studentsRepository;
        private readonly ICoursesRepository _coursesRepository;

        public RegistrarValidation(
            IStudentsRepository studentsRepository,
            ICoursesRepository coursesRepository)
        {
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
            _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));
        }

        public void ValidateCreateLessonGradeDTO(CreateLessonGradeDTO dto)
        {
            ValidateStudentIsRegisteredForTheCourse(dto.StudentId, dto.CourseId);

            var course = _coursesRepository.GetOrThrowException(dto.CourseId);
            if (!course.Lessons.Any(l => l.Id == dto.LessonId))
                throw new ArgumentException("Course does not contain the lesson");
        }

        public void ValidateStudentIsRegisteredForTheCourse(int studentId, int courseId)
        {
            var student = _studentsRepository.GetOrThrowException(studentId);
            if (!student.Courses.Any(c => c.Id == courseId))
                throw new ArgumentException("Student is not registered for the course");
        }
    }
}
