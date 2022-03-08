namespace MelloShell.Commands;

[CommandAttribute("cp")]
public class CopyFile : ICommand
{
    public void Run(string[] input)
    {
        string filename;
        string path;
        switch (input.Length)
        {
            case 1:
                path = Directory.GetCurrentDirectory();
                filename = input[0];
                break;
            case 2:
                path = input[1];
                filename = input[0];
                break;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
                return;
        }

        if (Directory.Exists(path))
        {
            bool overwrite = File.Exists($@"{path}\{filename}");
            File.Copy(filename, $@"{path}\{filename}", overwrite);
        }
        else
        {
            Console.WriteLine($"{path} does not exist");
        }
    }
}