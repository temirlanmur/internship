namespace TextEditorLogic.Commands
{
    public class DeleteCharCommand : BaseCommand, ICommand
    {
        private readonly string? backupLine;

        public DeleteCharCommand(TextEditor textEditor) : base(textEditor)
        {
            if (textEditor.RowCount <= textEditor.CursorRowIndex)
                backupLine = null;
            else
                backupLine = textEditor.text[textEditor.CursorRowIndex];
        }

        public void Execute() => textEditor.DeleteChar();

        public void Undo() => textEditor.text[textEditor.CursorRowIndex] = backupLine;
    }
}
