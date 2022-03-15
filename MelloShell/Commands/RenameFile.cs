namespace MelloShell.Commands;

/// <summary>
/// Renames files. <br/>
/// <remarks>Currently doesnt support renaming directories.</remarks>
/// Usage: <c>rename [options] [source] [suggested name]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Renames file "foo" to "bar".
/// <code>
///     rename foo bar
/// </code>
/// </summary>
[CommandAttribute("rename")]
public class RenameFile : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case 2:
                string originalname = input[0];
                string newname = input[1];
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