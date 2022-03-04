namespace MelloShell.Commands;

public interface ICommand
{
    void Run(string[]? input);
}