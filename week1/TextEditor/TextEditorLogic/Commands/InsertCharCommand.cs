namespace TextEditorLogic.Commands
{
    public class InsertCharCommand : BaseCommand, ICommand
    {
        private readonly char c;
        private readonly string? backupLine;
        public InsertCharCommand(TextEditor textEditor, char c) : base(textEditor)
        {
            this.c = c;

            if (textEditor.RowCount <= textEditor.CursorRowIndex)
                backupLine = null;
            else
                backupLine = textEditor.text[textEditor.CursorRowIndex];
        }

        public void Execute() => textEditor.InsertChar(c);

        public void Undo() => textEditor.text[textEditor.CursorRowIndex] = backupLine;
        
    }
}
