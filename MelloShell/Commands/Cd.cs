namespace MelloShell.Commands;

/// <summary>
/// Navigates to a directory. Supplying no directory outputs nothing.<br/>
/// 
/// Usage: <c>cd [options] [directory]</c> <br/>
/// Options:
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Navigates to the "testdir/ directory.
/// <code>
///     cd testdir
/// </code>
/// </summary>
[CommandAttribute("cd")]
public class Cd : ICommand
{
    public void Run(string[] input)
    {
        var path = "";
        switch (input.Length)
        {
            case 0:
                path = Directory.GetCurrentDirectory();
                break;
            case 1:
                path = input[0];
                break;
            default:
                Console.WriteLine("Error: This command takes 0-1 args");
                return;
        }

        if (Directory.Exists(path))
        {
            Directory.SetCurrentDirectory(path);
        }
        else
        {
            Console.WriteLine($"Error: {path} does not exist or is not a directory");
        }
    }
}