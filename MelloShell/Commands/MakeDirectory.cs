namespace MelloShell.Commands;

/// <summary>
/// Creates directories <br/>
/// 
/// Usage: <c>mkdir [options] [dirname(s)]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Creates directory "testdir1" and "testdir2" in the current directory.
/// <code>
///     mkdir testdir1 testdir2
/// </code>
/// </summary>
[CommandAttribute("mkdir")]
public class MakeDirectory : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var dirname in input)
                {
                    if (!Directory.Exists($@"{path}\{dirname}"))
                    {
                        Directory.CreateDirectory($@"{path}\{dirname}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {dirname} is an existing directory");
                    }
                }
                return;
            default:
                Console.WriteLine($"Error: This command takes 1 or more args");
                return;
        }
    }
}