namespace DotNetTasks.Abstractions.Interfaces
{
    public interface ICommand
    {
        void Execute();

        int Number { get; }

        string DisplayName { get; }
    }
}
