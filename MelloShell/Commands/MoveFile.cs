namespace MelloShell.Commands;

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