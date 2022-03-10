namespace MelloShell.Commands;

/// <summary>
/// Prints input to the console. <br/>
/// 
/// Usage: <c>echo [options] [string]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Outputs "Hello World!" to the console.
/// <code>
///     echo Hello World!
/// </code>
/// </summary>
[CommandAttribute("echo", Aliases = new []{"print"})]
public class Echo : ICommand
{
    public void Run(string[] input)
    {
        foreach (string str in input)
        {
            Console.WriteLine(str);
        }
    }
}