namespace MelloShell.Commands;

public class Ls : ICommand
{
    public void Run(string[]? input)
    {
        if (input is null)
        {
            string currentdir = Directory.GetCurrentDirectory();
            PrintFiles(currentdir);
        }
        else
        {
            foreach (string arg in input)
            {
                if (!Directory.Exists(arg))
                {
                    Console.Error.WriteLine($"Error: {arg} is not a valid argument or directory");
                    continue;
                }
                PrintFiles(arg);
            }
        }
    }

    private static void PrintFiles(string directory)
    {
        Console.WriteLine($"Directory: {directory}");
        Console.WriteLine("--------------------------------");
        string[] files = Directory.GetFileSystemEntries(directory);
        foreach (string file in files)
        {
            string filename = file.Split(@"\")[^1];
            if (Directory.Exists($@"{directory}\{filename}"))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            Console.Write($"{filename}\t");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
