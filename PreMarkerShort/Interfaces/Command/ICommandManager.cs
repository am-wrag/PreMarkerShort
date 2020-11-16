namespace PreMarkerShort.Interfaces
{
    public interface ICommandManager
    {
        void ExecuteCommand(ICommand command);
        void Undo();
        void Redo();
    }
}