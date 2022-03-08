namespace MelloShell.Commands;

[CommandAttribute("rm")]
public class RemoveFile : ICommand
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
            File.Delete($@"{path}\{filename}");
        }
        else
        {
            Console.WriteLine($"{path} does not exist");
        }
    }
}