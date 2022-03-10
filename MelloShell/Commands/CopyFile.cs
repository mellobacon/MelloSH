namespace MelloShell.Commands;

/// <summary>
/// Copies a file or multiple files to a directory. <br/>
/// <remarks>Currently doesnt support copying directories.</remarks>
/// Usage: <c>cp [options] [source] [dest]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text<br/>
/// -d: allows copying of directories<br/>
/// -p: prompts before overwriting<br/>
/// Example: <br/>
/// Copies the file "testfile1" to the "testdir" directory.
/// <code>
///     cp testfile1 testdir
/// </code>
/// </summary>
[CommandAttribute("cp")]
public class CopyFile : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case 1:
                CopyFiles(input[0], Directory.GetCurrentDirectory());
                return;
            case > 1:
                string dest = input[^1];
                for (int index = 0; index < input.Length - 1; index++)
                {
                    CopyFiles(input[index], dest);
                }
                
                return;
            default:
                Console.WriteLine("Error: This command takes 1 or more args");
                return;
        }
    }

    private static void CopyFiles(string source, string dest)
    {
        // Files cant be a directory
        if (source.Contains('\\') || source.Contains('/'))
        {
            Console.WriteLine($"Error: {source} cannot be a directory. Skipping.");
            return;
        }
        
        // TODO: fix "being used by another process" error. probably just need to close the stream
        if (Directory.Exists(dest))
        {
            bool overwrite = File.Exists($@"{dest}\{source}");
            try
            {
                File.Copy(source, $@"{dest}\{source}", overwrite);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine($"Error: {dest} does not exist");
        }
    }
}