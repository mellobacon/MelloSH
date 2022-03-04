namespace MelloShell.Commands;

[CommandAttribute("ls")]
public class Ls : ICommand
{
    private readonly string[] _options = { "-l", "-a", "-la"};
    public void Run(string[]? input)
    {
        string currentdir = Directory.GetCurrentDirectory();
        if (input!.Length == 0)
        {
            PrintFiles(currentdir);
        }
        else
        {
            var longlist = false;
            var showhiddenfiles = false;
            foreach (string arg in input)
            {
                if (!Directory.Exists(arg) && !_options.Contains(arg))
                {
                    Console.Error.WriteLine($"Error: {arg} is not a valid argument or directory");
                    continue;
                }
                if (Directory.Exists(arg))
                {
                    currentdir = arg;
                }

                if (arg == _options[0] || arg == _options[2]) longlist = true;
                if (arg == _options[1] || arg == _options[2]) showhiddenfiles = true;
                PrintFiles(currentdir, showhiddenfiles, longlist);
            }
        }
    }

    private static void PrintFiles(string directory, bool showhidden = false, bool longlist = false)
    {
        Console.WriteLine($"Directory: {directory}");
        Console.WriteLine("--------------------------------");
        string[] files = Directory.GetFileSystemEntries(directory);
        if (showhidden)
        {
            files = Directory.GetFileSystemEntries(directory, "*",
                new EnumerationOptions { ReturnSpecialDirectories = true });
        }
        foreach (string file in files)
        {
            string filename = file.Split(@"\")[^1];
            if (Directory.Exists($@"{directory}\{filename}"))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }

            if (longlist)
            {
                Console.WriteLine($"{filename}");
            }
            else
            {
                Console.Write($"{filename}\t");
            }
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
