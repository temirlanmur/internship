namespace TextEditorLogic.Commands
{
    public class DeleteCharCommand : BaseCommand, ICommand
    {
        private readonly List<string?> _backup;

        public DeleteCharCommand(TextEditor textEditor) : base(textEditor)
        {
            _backup = textEditor.GetTextCopy();
        }

        public void Execute()
        {
            var currRow = _textEditor.GetCurrentRow();
            var currColumnIndex = _textEditor.CurrentColumnIndex;

            if (string.IsNullOrWhiteSpace(currRow)) return;
            if (currRow.Length <= currColumnIndex) return;
            var modified = currRow.Remove(currColumnIndex, 1).Insert(currColumnIndex, " ");

            _textEditor.SetCurrentRow(modified);
        }


        public void Undo() => _textEditor.SetText(_backup);
    }
}
