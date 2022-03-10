namespace MelloShell.Commands;

/// <summary>
/// Clears the terminal. <br/>
/// 
/// Usage: <c>clear [options]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Clears terminal so that only the prompt remains...pretty self explanitory.
/// <code>
///     clear
/// </code>
/// </summary>
[CommandAttribute("clear", Aliases = new []{"cls", "clr"})]
public class Clear : ICommand
{
    public void Run(string[] input)
    {
        Console.Clear();
    }
}