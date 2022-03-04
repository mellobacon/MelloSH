namespace MelloShell.Commands;

public class Cd : ICommand
{
    public void Run(string[]? input)
    {
        if (input is null)
        {
            Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
            return;
        }

        if (Directory.Exists(input[0]))
        {
            Directory.SetCurrentDirectory(input[0]);
            Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
        }
        else
        {
            Console.Error.WriteLine($"Error: {input[0]} does not exist");
        }
    }
}