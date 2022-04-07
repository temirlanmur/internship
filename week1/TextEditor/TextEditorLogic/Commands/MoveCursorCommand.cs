namespace TextEditorLogic.Commands
{
    public class MoveCursorCommand : BaseCommand, ICommand
    {
        private readonly int _rowIndex;
        private readonly int _columnIndex;
        private readonly int _backupRowIndex;
        private readonly int _backupColumnIndex;

        public MoveCursorCommand(
            TextEditor textEditor,
            int rowIndex,
            int columnIndex) : base(textEditor)
        {            
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _backupRowIndex = textEditor.CurrentRowIndex;
            _backupColumnIndex = textEditor.CurrentColumnIndex;
        }

        public void Execute()
        {
            _textEditor.CurrentRowIndex = _rowIndex;
            _textEditor.CurrentColumnIndex = _columnIndex;
        }

        public void Undo()
        {
            _textEditor.CurrentRowIndex = _backupRowIndex;
            _textEditor.CurrentColumnIndex = _backupColumnIndex;
        }
    }
}
