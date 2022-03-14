namespace MelloShell.Commands;

/// <summary>
/// Prints the current directory <br/>
/// Usage: <c>pwd [options]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Prints the current directory...self explanitory
/// <code>
///     pwd
/// </code>
/// </summary>
[CommandAttribute("pwd")]
public class PrintCurrentDirectory : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case 0:
                Console.Out.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
                return;
            default:
                Console.WriteLine("Error: Type --help...i cant be bothered to explain how one messes up this command");
                return;
        }
    }
}