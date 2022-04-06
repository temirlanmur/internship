using System.Text;

namespace TextEditorLogic
{
    public class TextEditor
    {
        internal List<string?> text = new();        
        internal int RowCount => text.Count;
        
        public int CursorRowIndex { get; internal set; }
        public int CursorColumnIndex { get; internal set; }

        public TextEditor()            
        {            
            text.Add(" ");            
        }        

        internal void MoveCursorTo(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || colIndex < 0)
                throw new ArgumentException("Indexes cannot be less than 0");

            CursorRowIndex = rowIndex;
            CursorColumnIndex = colIndex;
        }

        internal void InsertChar(char c)
        {
            if (RowCount <= CursorRowIndex)   // trying to access row that haven't been initialized yet
            {
                var blankRowsNumber = CursorRowIndex - RowCount;

                var blankRows = CreateBlankRows(blankRowsNumber);
                text.AddRange(blankRows);

                var blankLine = CreateWhiteSpaceStringOfLength(CursorColumnIndex + 1, c);
                text.Insert(CursorRowIndex, blankLine);
            }
            else
            {
                var line = text[CursorRowIndex];

                if (line == null)   // Line had been initialized with null
                {
                    var blankLine = CreateWhiteSpaceStringOfLength(CursorColumnIndex + 1, c);
                    text[CursorRowIndex] = blankLine;
                }
                else if (line.Length <= CursorColumnIndex) // Line is a string, but it isn't long enough
                {
                    var remainingString = CreateWhiteSpaceStringOfLength(CursorColumnIndex - line.Length + 1, c);
                    text[CursorRowIndex] = line + remainingString;
                }
                else
                {
                    line = line.Insert(CursorColumnIndex, c.ToString());
                    line = line.Remove(CursorColumnIndex + 1);
                    text[CursorRowIndex] = line;
                }
            }
        }

        internal void DeleteChar()
        {
            if (RowCount <= CursorRowIndex) return;
            var line = text[CursorRowIndex];

            if (line == null || line.Length <= CursorColumnIndex) return;

            var sb = new StringBuilder(line);
            sb[CursorColumnIndex] = ' ';
            text[CursorRowIndex] = sb.ToString();
        }

        /// <summary>
        /// Returns IEnumerable of nulls of specified length.
        /// </summary>
        /// <param name="blankRowsNumber"></param>
        /// <returns></returns>
        private static IEnumerable<string?> CreateBlankRows(int blankRowsNumber)
        {
            var blankRows = new List<string?>();

            for (var i = 0; i < blankRowsNumber; i++)
            {
                blankRows.Add(null);
            }
            
            return blankRows;
        }        

        /// <summary>
        /// Returns a string of specified length, consisting of only white space characters except for the last character.        
        /// </summary>
        /// <param name="length"></param>
        /// <param name="lastCharacter"></param>
        /// <returns></returns>
        private static string CreateWhiteSpaceStringOfLength(int length, char lastCharacter)
        {
            var result = new string(' ', length - 1);
            return result + lastCharacter;
        }

        public void WriteTextToConsole()
        {
            foreach(var line in text)
                Console.WriteLine(line);
        }
    }
}
