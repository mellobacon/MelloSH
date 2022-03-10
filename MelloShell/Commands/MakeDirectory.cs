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
                        Console.WriteLine($"Error: idk something with the directory is wrong. figure it out");
                    }
                }
                return;
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }
    }
}