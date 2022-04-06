namespace TextEditorLogic.Commands
{
    public class MoveCursorCommand : BaseCommand, ICommand
    {
        private readonly int rowIndex;
        private readonly int columnIndex;
        private readonly int backupRowIndex;
        private readonly int backupColumnIndex;

        public MoveCursorCommand(
            TextEditor textEditor,
            int rowIndex,
            int columnIndex) : base(textEditor)
        {            
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            backupRowIndex = textEditor.CursorRowIndex;
            backupColumnIndex = textEditor.CursorColumnIndex;
        }

        public void Execute() => textEditor.MoveCursorTo(rowIndex, columnIndex);

        public void Undo()
        {
            textEditor.CursorRowIndex = backupRowIndex;
            textEditor.CursorColumnIndex = backupColumnIndex;
        }
    }
}
