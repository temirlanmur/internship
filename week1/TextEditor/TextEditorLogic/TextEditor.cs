using System.Text;

namespace TextEditorLogic
{
    public class TextEditor
    {
        private List<string?> _text = new();        

        public int RowCount => _text.Count;
        public int CurrentRowIndex { get; internal set; }
        public int CurrentColumnIndex { get; internal set; }
        
        public TextEditor()            
        {            
            _text.Add(string.Empty);
        }

        /// <summary>
        /// Retrieves row at specified index
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal string GetRow(int rowIndex)
        {
            if (rowIndex < 0) 
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            if (this.RowCount <= rowIndex)
                return string.Empty;
            else
                return _text[rowIndex]?.TrimEnd() ?? string.Empty;
        }

        internal string GetCurrentRow() => GetRow(CurrentRowIndex);

        /// <summary>
        /// Sets specified string at specified row index
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void SetRow(int rowIndex, string value)
        {
            if (rowIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            if (this.RowCount <= rowIndex)
            {
                AppendBlankLines(rowIndex - RowCount);
                _text.Insert(rowIndex, value);
            }
            else
                _text[rowIndex] = value;
        }
        
        internal void SetCurrentRow(string value) => SetRow(CurrentRowIndex, value);

        /// <summary>
        /// Returns current copy of the text
        /// </summary>
        /// <returns></returns>
        internal List<string?> GetTextCopy()
            => _text.Select(line => string.IsNullOrWhiteSpace(line) ? null : new string(line)).ToList();

        /// <summary>
        /// Sets the text to the specified parameter
        /// </summary>
        /// <param name="text"></param>
        internal void SetText(List<string?> text) => _text = text;

        private void AppendBlankLines(int blankLinesNumber)
        {
            var blankLines = new List<string?>();
            for (var i = 0; i < blankLinesNumber; i++)
                blankLines.Add(null);
            _text.AddRange(blankLines);
        }

        public void WriteTextToConsole()
        {
            foreach(var line in _text)
                Console.WriteLine(line);
        }
    }
}
