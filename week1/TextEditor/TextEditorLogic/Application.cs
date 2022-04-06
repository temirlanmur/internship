using TextEditorLogic.Commands;

namespace TextEditorLogic
{
    public class Application
    {
        private readonly TextEditor textEditor;
        private Stack<ICommand> commandHistory;
        private Stack<ICommand> cancelledCommands;

        public Application()
        {
            textEditor = new();
            commandHistory = new();
            cancelledCommands = new();
        }
        
        public void MoveCursor(int rowIndex, int colIndex) => ExecuteCommand(new MoveCursorCommand(textEditor, rowIndex, colIndex));  
        public void InsertChar(char c) => ExecuteCommand(new InsertCharCommand(textEditor, c));
        public void DeleteChar() => ExecuteCommand(new DeleteCharCommand(textEditor));

        public void Undo()
        {
            if (commandHistory.Count > 0)
            {
                var command = commandHistory.Pop();
                command.Undo();
                cancelledCommands.Push(command);
            }
        }

        public void Redo()
        {
            if (cancelledCommands.Count > 0)
            {
                var command = cancelledCommands.Pop();
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        public void PrintText() => textEditor.WriteTextToConsole();
    }
}
