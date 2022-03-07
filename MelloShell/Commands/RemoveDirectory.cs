namespace MelloShell.Commands;

[CommandAttribute("rmdir")]
public class RemoveDirectory : ICommand
{
    public void Run(string[] input)
    {
        string path;
        string dirname;
        switch (input.Length)
        {
            case 1:
                path = Directory.GetCurrentDirectory();
                dirname = input[0];
                break;
            case 2:
                path = input[0];
                dirname = input[1];
                break;
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }

        if (Directory.Exists(path) || !Directory.Exists($@"{path}\{dirname}"))
        {
            Directory.Delete($@"{path}\{dirname}");
        }
        else
        {
            Console.WriteLine($"Error: idk something with the directory is wrong. figure it out");
        }
    }
}