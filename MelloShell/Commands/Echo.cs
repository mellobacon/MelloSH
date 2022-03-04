namespace MelloShell.Commands;

[CommandAttribute("echo")]
public class Echo : ICommand
{
    public void Run(string[]? input)
    {
        if (input is null) return;
        foreach (string str in input)
        {
            Console.WriteLine(str);
        }
    }
}