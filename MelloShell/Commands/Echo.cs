namespace MelloShell.Commands;

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