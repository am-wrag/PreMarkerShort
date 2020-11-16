namespace PreMarkerShort.Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}