namespace MelloShell.Commands;

/// <summary>
/// Lists the directories and files of a directory and its information.
/// No input prints from the current directory. <br/>
/// 
/// Usage: <c>ls [options] [directory(s)]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text<br/>
/// -l: Prints this help text<br/>
/// -a: Include hidden directories<br/>
/// Example: <br/>
/// Prints the files of the "testdir" directory
/// <code>
///     ls testdir
/// </code>
/// </summary>
[CommandAttribute("ls")]
public class Ls : ICommand
{
    private readonly string[] _options = { "-l", "-a", "-la"};
    public void Run(string[] input)
    {
        string currentdir = Directory.GetCurrentDirectory();
        if (input.Length == 0)
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

                if (arg.Equals(_options[0]) || arg.Equals(_options[2])) longlist = true;
                if (arg.Equals(_options[1]) || arg.Equals(_options[2])) showhiddenfiles = true;
                PrintFiles(currentdir, showhiddenfiles, longlist);
            }
        }
    }
    
    private static void PrintFiles(string directory, bool showhidden = false, bool longlist = false)
    {
        Console.WriteLine("--------------------------------");
        FileAttributes fileAttributes = showhidden ? FileAttributes.System 
            : FileAttributes.System | FileAttributes.Hidden;
        string[] files = Directory.GetFileSystemEntries(directory, "*",
            new EnumerationOptions { ReturnSpecialDirectories = showhidden, AttributesToSkip = fileAttributes});
        foreach (string file in files)
        {
            string filename = file.Split(@"\")[^1];
            var f = new FileInfo(filename);
            
            if (longlist)
            {
                var archive = '-';
                var compressed = '-';
                var _directory = '-';
                var hidden = '-';
                var _readonly = '-';
                if ((f.Attributes & FileAttributes.Archive) != 0)
                {
                    archive = 'a';
                }

                if ((f.Attributes & FileAttributes.Compressed) != 0)
                {
                    compressed = 'c';
                }

                if ((f.Attributes & FileAttributes.Directory) != 0)
                {
                    _directory = 'd';
                }

                if ((f.Attributes & FileAttributes.Hidden) != 0)
                {
                    hidden = 'h';
                }
                if ((f.Attributes & FileAttributes.ReadOnly) != 0)
                {
                    _readonly = 'r';
                }

                string attributes = $"{_directory}{archive}{_readonly}{compressed}{hidden}";
                
                Console.Write($"{attributes}\t{f.LastWriteTime}\t");
            }
            
            if ((File.GetAttributes($@"{directory}\{filename}") & FileAttributes.Directory) != 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.Write($"{filename}");
            Console.ResetColor();
            if (longlist)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write("    ");
            }
        }
        Console.WriteLine();
    }
}
