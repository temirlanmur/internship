using Moq;
using System;
using System.Reflection;
using TrainingCenter.Core.Interfaces.Repositories;
using TrainingCenter.Core.Models;
using TrainingCenter.Core.Services;
using Xunit;

namespace TrainingCenter.Core.Tests
{
    public class ManagementServiceTests
    {        
        [Fact]
        public void Adding_Already_Present_Lesson_To_The_Course_Throws_Exception()
        {
            // Arange
            var course = CreateCourseWithId(3);
            var lesson = CreateLessonWithId(15);
            
            course.Lessons.Add(lesson);

            var studentsRepoMock = new Mock<IStudentsRepository>();
            var teachersRepoMock = new Mock<ITeachersRepository>();
            var coursesRepoMock = new Mock<ICoursesRepository>();
            var lessonsRepoMock = new Mock<ILessonsRepository>();

            coursesRepoMock
                .Setup(x => x.GetOrThrowException(3))
                .Returns(course);

            var sut = new ManagementService(
                studentsRepoMock.Object,
                teachersRepoMock.Object,
                coursesRepoMock.Object,
                lessonsRepoMock.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => sut.AddLessonToCourse(3, 15));
        }

        /// <summary>
        /// Returns course instance with provided id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        private Course CreateCourseWithId(int courseId)
        {
            var course = new Course("Intro to Testing");            

            // Use Reflection to set Id of the course
            PropertyInfo propertyInfo = typeof(Course).GetProperty("Id");
            propertyInfo.SetValue(course, courseId);         
            
            return course;
        }

        /// <summary>
        /// Returns lesson instance with provided id
        /// </summary>
        /// <param name="lessonId"></param>
        /// <returns></returns>
        private Lesson CreateLessonWithId(int lessonId)
        {
            var lesson = new Lesson("Lesson 1");

            // Use Reflection to set Id of the lesson
            PropertyInfo propertyInfo = typeof(Lesson).GetProperty("Id");
            propertyInfo.SetValue(lesson, lessonId);

            return lesson;
        }
    }
}