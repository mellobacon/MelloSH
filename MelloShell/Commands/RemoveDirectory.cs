namespace MelloShell.Commands;

[CommandAttribute("rmdir", Aliases = new []{"rm"})]
public class RemoveDirectory : ICommand
{
    public void Run(string[]? input)
    {
        switch (input!.Length)
        {
            case 1:
                try
                {
                    Directory.Delete($@"{Directory.GetCurrentDirectory()}\{input[0]}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                return;
            case 2:
                try
                {
                    if (Directory.Exists(input[0]))
                    {
                        Directory.Delete($@"{input[0]}\{input[1]}");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                return;
            default:
                Console.WriteLine($"Error: No arguments given");
                return;
        }
    }
}