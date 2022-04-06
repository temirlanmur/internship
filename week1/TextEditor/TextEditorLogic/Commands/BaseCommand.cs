namespace TextEditorLogic.Commands
{
    public class BaseCommand
    {
        protected readonly TextEditor textEditor;        

        public BaseCommand(TextEditor textEditor) => this.textEditor = textEditor;        
    }
}
