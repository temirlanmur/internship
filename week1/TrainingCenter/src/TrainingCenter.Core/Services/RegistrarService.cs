using TrainingCenter.Core.DTOs;
using TrainingCenter.Core.Interfaces.Repositories;
using TrainingCenter.Core.Interfaces.Services;
using TrainingCenter.Core.Interfaces.Validation;
using TrainingCenter.Core.Models;
using TrainingCenter.Core.Models.Enums;

namespace TrainingCenter.Core.Services
{
    public class RegistrarService : IRegistrarService
    {
        private readonly IRegistrarValidation _registrarValidation;                
        private readonly IGradesRepository _gradesRepository;

        public RegistrarService(
            IRegistrarValidation registrarValidation,                                    
            IGradesRepository gradesRepository)
        {
            _registrarValidation = registrarValidation ?? throw new ArgumentNullException(nameof(registrarValidation));            
            _gradesRepository = gradesRepository ?? throw new ArgumentNullException(nameof(gradesRepository));
        }

        public void GiveStudentLessonGrade(CreateLessonGradeDTO dto)
        {
            _registrarValidation.ValidateCreateLessonGradeDTO(dto);            

            var lessonGrade = new Grade()
            {
                GradeType = GradeType.LessonGrade,
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                LessonId = dto.LessonId,
                GradeValue = dto.Grade
            };

            _gradesRepository.Save(lessonGrade);
        }

        public decimal CalculateStudentFinalScore(int studentId, int courseId)
        {
            _registrarValidation.ValidateStudentIsRegisteredForTheCourse(studentId, courseId);

            var lessonGrades = _gradesRepository.GetStudentLessonGrades(studentId, courseId);

            var finalCourseGrade = CalculateAverageGrade(lessonGrades);

            var courseGrade = new Grade
            {
                GradeType = GradeType.CourseGrade,
                StudentId = studentId,
                CourseId = courseId,
                LessonId = null,
                GradeValue = finalCourseGrade
            };

            _gradesRepository.Save(courseGrade);

            return CalculateAverageGrade(lessonGrades);
        }        

        private static decimal CalculateAverageGrade(IEnumerable<Grade> lessonGrades)
        {            
            return lessonGrades.Sum(g => g.GradeValue) / lessonGrades.Count();
        }
    }
}
