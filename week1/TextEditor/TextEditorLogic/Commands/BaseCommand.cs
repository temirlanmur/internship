namespace TextEditorLogic.Commands
{
    public class BaseCommand
    {
        protected readonly TextEditor _textEditor;        

        public BaseCommand(TextEditor textEditor) => _textEditor = textEditor;        
    }
}
