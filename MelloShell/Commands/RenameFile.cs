namespace MelloShell.Commands;

[CommandAttribute("rename")]
public class RenameFile : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case 2:
                var originalname = input[0];
                var newname = input[1];
                if (originalname.Equals(newname))
                {
                    Console.WriteLine($"Error: {originalname} and {newname} are the same file");
                }
                else if (File.Exists(originalname))
                {
                    File.Move(originalname, newname, true);
                }
                else
                {
                    Console.WriteLine($"Error: {originalname} doesnt exist");
                }
                return;
            default:
                Console.WriteLine("Error: This command takes 2 args");
                return;
        }
    }
}