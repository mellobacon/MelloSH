namespace MelloShell.Commands;

/// <summary>
/// Creates files or changes files access time. <br/>
/// Usage: <c>touch [options] [filename(s)]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Creates a file named "testfile1".
/// <code>
///     touch tesfile1
/// </code>
/// </summary>
[CommandAttribute("touch", Aliases = new []{"createfile"})]
public class CreateFile : ICommand
{
    public void Run(string[] input)
    {
        string path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (string filename in input)
                {
                    CreateFiles(filename, path);
                }
                break;
            default:
                Console.WriteLine("Error: An error occurred. Try again");
                return;
        }
    }

    private static void CreateFiles(string filename, string dest)
    {
        // Files cant be a directory
        if (filename.Contains('\\') || filename.Contains('/'))
        {
            Console.WriteLine($"Error: {filename} cannot be a directory. Skipping.");
            return;
        }
        if (File.Exists($@"{dest}\{filename}"))
        {
            File.SetLastWriteTime($@"{dest}\{filename}", DateTime.Now);
            
            return;
        }

        using FileStream file = File.Create($@"{dest}\{filename}");
        file.Dispose();
    }
}