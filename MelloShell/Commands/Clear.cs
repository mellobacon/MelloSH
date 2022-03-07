namespace MelloShell.Commands;

[CommandAttribute("clear", Aliases = new []{"cls", "clr"})]
public class Clear : ICommand
{
    public void Run(string[] input)
    {
        Console.Clear();
    }
}