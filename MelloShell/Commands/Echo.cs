namespace MelloShell.Commands;

public class Echo : ICommand
{
    public void Run(object? input)
    {
        if (input is string[] args)
        {
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }
        }
    }
}