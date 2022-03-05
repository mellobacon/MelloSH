namespace MelloShell.Commands;

[CommandAttribute("mkdir")]
public class MakeDirectory : ICommand
{
    public void Run(string[]? input)
    {
        switch (input!.Length)
        {
            case 1:
                try
                {
                    Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\{input[0]}");
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
                        Directory.CreateDirectory($@"{input[0]}\{input[1]}");
                    }
                }
                catch (Exception e)
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