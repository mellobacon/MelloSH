namespace MelloShell.Commands;

public class Cd : ICommand
{
    public void Run(object? input)
    {
        if (input is string[] dir)
        {
            if (dir.Length == 0)
            {
                Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
                return;
            }

            if (Directory.Exists(dir[0]))
            {
                Directory.SetCurrentDirectory(dir[0]);
                Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
            }
            else
            {
                Console.Error.WriteLine($"Error: {dir[0]} does not exist");
            }
        }
    }
}