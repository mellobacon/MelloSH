namespace MelloShell.Commands;

/**
 * Copies a file or multiple files to a directory
 * Usage: cp [options] [source] [dest]
 * options:
 *  -d: allows copying of directories
 *  -p: prompts before overwriting
 */
[CommandAttribute("cp")]
public class CopyFile : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case 1:
                CopyFiles(input[0], Directory.GetCurrentDirectory());
                return;
            case > 1:
                string dest = input[^1];
                for (int index = 0; index < input.Length - 1; index++)
                {
                    CopyFiles(input[index], dest);
                }
                
                return;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
                return;
        }
    }

    private static void CopyFiles(string source, string dest)
    {
        // Files cant be a directory
        if (source.Contains('\\') || source.Contains('/'))
        {
            Console.WriteLine($"Error: {source} cannot be a directory. Skipping.");
            return;
        }
        
        // TODO: fix "being used by another process" error. probably just need to close the stream
        if (Directory.Exists(dest))
        {
            bool overwrite = File.Exists($@"{dest}\{source}");
            try
            {
                File.Copy(source, $@"{dest}\{source}", overwrite);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine($"{dest} does not exist");
        }
    }
}