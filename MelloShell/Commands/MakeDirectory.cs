namespace MelloShell.Commands;

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