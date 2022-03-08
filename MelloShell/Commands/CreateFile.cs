namespace MelloShell.Commands;

[CommandAttribute("touch", Aliases = new []{"createfile"})]
public class CreateFile : ICommand
{
    public void Run(string[] input)
    {
        string filename;
        var path = "";
        switch (input.Length)
        {
            case 1:
                filename = input[0];
                path = Directory.GetCurrentDirectory();
                break;
            case 2:
                filename = input[0];
                path = input[1];
                break;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
                return;
        }

        if (Directory.Exists(path))
        {
            File.Create($@"{path}\{filename}");
        }
        else
        {
            Console.WriteLine($"{path} does not exist");
        }
    }
}