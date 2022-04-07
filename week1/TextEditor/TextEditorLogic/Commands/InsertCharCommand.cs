namespace TextEditorLogic.Commands
{
    public class InsertCharCommand : BaseCommand, ICommand
    {
        private readonly char _c;
        private readonly List<string?> _backup;

        public InsertCharCommand(TextEditor textEditor, char c) : base(textEditor)
        {
            _c = c;
            _backup = textEditor.GetTextCopy();
        }

        public void Execute()
        {
            var currRow = _textEditor.GetCurrentRow();
            var currColumnIndex = _textEditor.CurrentColumnIndex;
            string modified;

            if (string.IsNullOrWhiteSpace(currRow))
                modified = _c.ToString().AddWhiteSpaceCharsFront(currColumnIndex);

            else if (currRow.Length <= currColumnIndex)
                modified = currRow + _c.ToString().AddWhiteSpaceCharsFront(currColumnIndex - currRow.Length);

            else
                modified = currRow.Remove(currColumnIndex, 1).Insert(currColumnIndex, _c.ToString());

            _textEditor.SetCurrentRow(modified);
        }

        public void Undo() => _textEditor.SetText(_backup);        
    }
}
