namespace MelloShell.Commands;

/// <summary>
/// Deletes directories. <br/>
/// 
/// Usage: <c>rmdir [options] [directory(s)]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Deletes directory "testdir2" in "testdir". "testdir" does not get removed.
/// <code>
///     rmdir testdir/testdir2
/// </code>
/// </summary>
[CommandAttribute("rmdir")]
public class RemoveDirectory : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var dirname in input)
                {
                    if (Directory.Exists($@"{path}\{dirname}"))
                    {
                        // Directory must be empty
                        if (Directory.GetFileSystemEntries($@"{path}\{dirname}").Length == 0)
                        {
                            Directory.Delete($@"{path}\{dirname}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Directory must be empty");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {dirname} is not an existing directory");
                    }
                }
                return;
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }
    }
}