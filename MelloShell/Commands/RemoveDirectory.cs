namespace MelloShell.Commands;

[CommandAttribute("rmdir")]
public class RemoveDirectory : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var dirname in input)
                {
                    if (Directory.Exists($@"{path}\{dirname}"))
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
                return;
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }
    }
}