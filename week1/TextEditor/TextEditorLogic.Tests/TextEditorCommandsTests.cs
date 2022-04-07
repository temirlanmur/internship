using Xunit;

namespace TextEditorLogic.Tests
{
    public class TextEditorCommandsTests
    {
        [Fact]
        public void Insert_Command_Works_Correctly()
        {
            // Arrange
            var sut = GetApp();
            var expectedLine = "a";

            // Act
            sut.InsertChar('a');

            // Assert
            Assert.Equal(expectedLine, sut.TEST_GetCurrentRow());
        }

        [Fact]
        public void Move_Cursor_Command_Works_Correctly()
        {
            // Arrange
            var sut = GetApp();
            var expectedLine = "  a";

            // Act
            sut.MoveCursor(2, 2);
            sut.InsertChar('a');

            // Assert
            Assert.Equal(expectedLine, sut.TEST_GetRow(2));
        }

        [Fact]
        public void Delete_Char_Command_Works_Correctly()
        {
            // Arrange
            var sut = GetApp();
            var expectedLine = "a";

            // Act            
            sut.InsertChar('a');
            sut.MoveCursor(0, 1);
            sut.InsertChar('a');
            sut.DeleteChar();

            // Assert
            Assert.Equal(expectedLine, sut.TEST_GetCurrentRow());
        }

        [Fact]
        public void Undo_Command_Works_Correctly()
        {
            // Arrange
            var sut = GetApp();
            var expectedLine = "a";

            // Act            
            sut.InsertChar('a');
            sut.MoveCursor(0, 1);
            sut.InsertChar('a');
            sut.Undo();

            // Assert
            Assert.Equal(expectedLine, sut.TEST_GetCurrentRow());
        }


        [Fact]
        public void Redo_Command_Works_Correctly()
        {
            // Arrange
            var sut = GetApp();
            var expectedLine = "a";

            // Act            
            sut.InsertChar('a');
            sut.Undo();
            sut.Redo();            

            // Assert
            Assert.Equal(expectedLine, sut.TEST_GetCurrentRow());
        }

        private Application GetApp() => new();
    }
}