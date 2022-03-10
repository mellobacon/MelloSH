namespace MelloShell.Commands;

/**
 * Makes files but in the current dirctory because im lazy (for now.
 * probably gonna have renaming be a thing too at some point)
 * Usage: touch [filename]
 */
[CommandAttribute("touch", Aliases = new []{"createfile"})]
public class CreateFile : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var filename in input)
                {
                    CreateFiles(filename, path);
                }
                break;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
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
        // TODO: fix "being used by another process" error. probably just need to close the stream
        if (File.Exists($@"{dest}\{filename}"))
        {
            File.SetLastWriteTime($@"{dest}\{filename}", DateTime.Now);
            
            return;
        }
        File.Create($@"{dest}\{filename}");
    }
}