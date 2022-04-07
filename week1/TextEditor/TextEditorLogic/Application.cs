using TextEditorLogic.Commands;

namespace TextEditorLogic
{
    public class Application
    {
        private readonly TextEditor _textEditor;
        private Stack<ICommand> _commandHistory;
        private Stack<ICommand> _cancelledCommands;

        public Application()
        {
            _textEditor = new();
            _commandHistory = new();
            _cancelledCommands = new();
        }
        
        public void MoveCursor(int rowIndex, int colIndex) => ExecuteCommand(new MoveCursorCommand(_textEditor, rowIndex, colIndex));  
        public void InsertChar(char c) => ExecuteCommand(new InsertCharCommand(_textEditor, c));
        public void DeleteChar() => ExecuteCommand(new DeleteCharCommand(_textEditor));

        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                command.Undo();
                _cancelledCommands.Push(command);
            }
        }

        public void Redo()
        {
            if (_cancelledCommands.Count > 0)
            {
                var command = _cancelledCommands.Pop();
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void PrintText() => _textEditor.WriteTextToConsole();

        /// <summary>
        /// For testing purposes only!
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public string TEST_GetRow(int rowIndex) => _textEditor.GetRow(rowIndex);

        /// <summary>
        /// For testing purposes only!
        /// </summary>
        /// <returns></returns>
        public string TEST_GetCurrentRow() => _textEditor.GetCurrentRow();        
    }
}
