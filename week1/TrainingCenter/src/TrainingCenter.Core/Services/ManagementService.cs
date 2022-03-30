using TrainingCenter.Core.Interfaces.Repositories;
using TrainingCenter.Core.Interfaces.Services;

namespace TrainingCenter.Core.Services
{
    public class ManagementService : IManagementService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ITeachersRepository _teachersRepository;
        private readonly ICoursesRepository _coursesRepository;
        private readonly ILessonsRepository _lessonsRepository;

        public ManagementService(
            IStudentsRepository studentsRepository,
            ITeachersRepository teachersRepository,
            ICoursesRepository coursesRepository,
            ILessonsRepository lessonsRepository)
        {
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
            _teachersRepository = teachersRepository ?? throw new ArgumentNullException(nameof(teachersRepository));
            _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));
            _lessonsRepository = lessonsRepository ?? throw new ArgumentNullException(nameof(lessonsRepository));
        }

        public void AddLessonToCourse(int courseId, int lessonId)
        {
            var course = _coursesRepository.GetOrThrowException(courseId);

            if (course.Lessons.Any(l => l.Id == lessonId))
                throw new ArgumentException("Lesson is already present in the course");
                        
            var lesson = _lessonsRepository.GetOrThrowException(lessonId);

            lesson.CourseId = courseId;
            _lessonsRepository.Save(lesson);
        }

        public void AssignStudentToCourse(int courseId, int studentId)
        {
            var course = _coursesRepository.GetOrThrowException(courseId);
            var student = _studentsRepository.GetOrThrowException(studentId);           

            student.Courses.Add(course);
            _studentsRepository.Save(student);
        }

        public void AssignTeacherToCourse(int courseId, int teacherId)
        {
            var course = _coursesRepository.GetOrThrowException(courseId);
            var teacher = _teachersRepository.GetOrThrowException(teacherId);

            teacher.Courses.Add(course);
            _teachersRepository.Save(teacher);
        }
    }
}
