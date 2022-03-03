namespace MelloShell.Commands;

public interface ICommand
{
    void Run(object? input);
}