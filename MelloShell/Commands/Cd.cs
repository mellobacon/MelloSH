namespace MelloShell.Commands;

[CommandAttribute("cd")]
public class Cd : ICommand
{
    public void Run(string[] input)
    {
        var path = "";
        switch (input.Length)
        {
            case 0:
                path = Directory.GetCurrentDirectory();
                break;
            case 1:
                path = input[0];
                break;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
                return;
        }

        if (Directory.Exists(path))
        {
            Directory.SetCurrentDirectory(path);
        }
        else
        {
            Console.WriteLine($"Error: {path} does not exist or is not a directory");
        }
    }
}