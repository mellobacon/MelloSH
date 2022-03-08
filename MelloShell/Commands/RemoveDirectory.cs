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
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }

        if (Directory.Exists(path))
        {
            // Directory must be empty
            if (Directory.GetFileSystemEntries($@"{path}\{dirname}").Length == 0)
            {
                Directory.Delete($@"{path}\{dirname}");
            }
            else
            {
                Console.WriteLine("Error: Directory must be empty");
            }
        }
        else
        {
            Console.WriteLine($"Error: idk something with the directory is wrong. figure it out");
        }
    }
}