namespace MelloShell.Commands;

/// <summary>
/// Copies a file/directory or multiple files/directories to a destination directory. If file exits it will overwrite. <br/>
/// <remarks>Currently doesnt support copying directories.</remarks>
/// Usage: <c>cp [options] [source] [dest]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text<br/>
/// -d: allows copying of directories<br/>
/// -p: prompts before overwriting<br/>
/// Example: <br/>
/// Copies the file "testfile1" to the "testdir" directory.
/// <code>
///     cp testfile1 testdir
/// </code>
/// </summary>
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
                for (var index = 0; index < input.Length - 1; index++)
                {
                    CopyFiles(input[index], dest);
                }
                
                return;
            default:
                Console.WriteLine("Error: This command takes 1 or more args");
                return;
        }
    }

    private static void CopyFiles(string source, string dest)
    {
        if (Directory.Exists(source))
        {
            string path = $@"{dest}\{source.Split(@"\")[^1]}";
            Directory.CreateDirectory(path);
            if (Directory.GetFiles(source).Length > 0)
            {
                var files = Directory.GetFiles(source);
                foreach (string file in files)
                {
                    var filename = file.Split(@"\")[^1];
                    CopyFiles($@"{source}\{filename}", $@"{path}\{filename}");
                }
            }

            if (Directory.GetDirectories(source).Length > 0)
            {
                var dirs = Directory.GetDirectories(source);
                foreach (string dir in dirs)
                {
                    CopyFiles(dir, path);
                }
            }
            return;
        }

        // TODO: fix parsing filepaths because doing something like 'path/' works but 'path/to/whatever' does not because my code is stupid
        string sourcename = source;
        string destname = dest;
        if (!Directory.Exists(dest))
        {
            if (dest.Contains('\\'))
            {
                destname = dest.Remove(dest.LastIndexOf('\\'));
            }
            else if (dest.Contains('/'))
            {
                destname = dest.Remove(dest.LastIndexOf('/'));
            }
        }
        if (Directory.Exists(destname))
        {
            if (source.Contains('\\'))
            {
                sourcename = source.Split(@"\")[^1];
            }
            bool overwrite = File.Exists($@"{destname}\{sourcename}");
            try
            {
                File.Copy(source, $@"{destname}\{sourcename}", overwrite);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine($"Error: {dest} does not exist");
        }
    }
}