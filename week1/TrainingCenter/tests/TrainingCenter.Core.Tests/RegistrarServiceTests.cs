using Moq;
using System;
using TrainingCenter.Core.DTOs;
using TrainingCenter.Core.Interfaces.Repositories;
using TrainingCenter.Core.Models;
using TrainingCenter.Core.Services;
using TrainingCenter.Core.Validation;
using Xunit;

namespace TrainingCenter.Core.Tests
{
    public class RegistrarServiceTests
    {
        [Fact]
        public void Giving_Nonexistent_Student_Grade_Throws_Exception()
        {
            // Arrange
            var studentsRepoMock = new Mock<IStudentsRepository>();
            var coursesRepoMock = new Mock<ICoursesRepository>();
            var gradesRepoMock = new Mock<IGradesRepository>();

            studentsRepoMock
                .Setup(x => x.GetOrThrowException(1))
                .Throws<ArgumentException>();

            var validation = new RegistrarValidation(
                studentsRepoMock.Object,
                coursesRepoMock.Object);

            var dto = new CreateLessonGradeDTO
            {
                StudentId = 1,
                CourseId = 1,
                LessonId = 1,
                Grade = 100
            };

            var sut = new RegistrarService(validation, gradesRepoMock.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => sut.GiveStudentLessonGrade(dto));
        }

        [Fact]
        public void Calculating_Final_Grade_For_Student_Not_Registered_For_The_Course_Throws_Exception()
        {
            // Arrange
            var student = new Student("Martin Eden"); // is not registered for any course

            var studentsRepoMock = new Mock<IStudentsRepository>();
            var coursesRepoMock = new Mock<ICoursesRepository>();
            var gradesRepoMock = new Mock<IGradesRepository>();

            studentsRepoMock
                .Setup(x => x.GetOrThrowException(1))
                .Returns(student);

            var validation = new RegistrarValidation(
                studentsRepoMock.Object,
                coursesRepoMock.Object);

            var dto = new CreateLessonGradeDTO
            {
                StudentId = 1,
                CourseId = 1,
                LessonId = 1,
                Grade = 100
            };

            var sut = new RegistrarService(validation, gradesRepoMock.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => sut.CalculateStudentFinalScore(1, 3));
        }        
    }
}
