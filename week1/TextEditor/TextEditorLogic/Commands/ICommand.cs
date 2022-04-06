namespace TextEditorLogic.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
