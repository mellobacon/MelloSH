namespace MelloShell.Commands;

/// <summary>
/// Moves files or directories to another directory. <br/>
/// <remarks>Does not support renaming files or directories. See <see cref="RenameFile">rename</see>.</remarks>
/// Usage: <c>mv [options] [source name] [dest name]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Moves the file "testfile1" to the directory "testdir2"
/// <code>
///     mv testfile1 testdir2
/// </code>
/// </summary>
[CommandAttribute("mv", Aliases = new []{"move"})]
public class MoveFile : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case > 1:
                var dest = input[^1];
                if (Directory.Exists(dest))
                {
                    for (int index = 0; index < input.Length - 1; index++)
                    {
                        if (input[index].Equals(dest))
                        {
                            Console.WriteLine($"Error: {input[0]} and {dest} are the same name. Dont do that smh");
                            continue;
                        }
                        if (File.Exists(input[index]))
                        {
                            Directory.Move(input[index], $@"{dest}\{input[index]}");
                        }
                        else
                        {
                            Console.WriteLine($"Error: {input[index]} does not exist");
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine($"Error: {dest} does not exist");
                }
                return;
            default:
                Console.WriteLine("Error: This command takes 1 or more args");
                return;
        }
    }
}