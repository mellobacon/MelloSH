namespace MelloShell.Commands;

/// <summary>
/// Deletes files. <br/>
/// 
/// Usage: <c>rm [options] [file(s)]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Deletes the files "testfile1" and "testfile2" in the current directory.
/// <code>
///     rm testfile1 testfile2
/// </code>
/// </summary>
[CommandAttribute("rm")]
public class RemoveFile : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var filename in input)
                {
                    if (File.Exists(filename))
                    {
                        File.Delete($@"{path}\{filename}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {filename} does not exist");
                    }
                }

                return;
            default:
                Console.WriteLine("Error: This command takes 1 or more args");
                return;
        }
    }
}