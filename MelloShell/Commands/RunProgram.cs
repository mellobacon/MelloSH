using System.Diagnostics;

namespace MelloShell.Commands;

/// <summary>
/// Runs a program. <br/>
/// <remarks>Command is a work in progress.</remarks>
/// Usage: <c>run [options] [program]</c> <br/>
/// Options: <br/>
/// -h, --h, --help: Prints this help text <br/>
/// Example: <br/>
/// Runs the exe "somescript".
/// <code>
///     run somescript.exe
/// </code>
/// </summary>
[CommandAttribute("run", Aliases = new []{"./"})]
public class RunProgram : ICommand
{
    public void Run(string[] input)
    {
        switch (input.Length)
        {
            case > 0:
                // TODO: yea this is uh. jank. should find a way to make files start from the current directory
                var args = @$"{Directory.GetCurrentDirectory()}/{string.Join(" ", input[1..])}";
                var startInfo = new ProcessStartInfo
                {
                    FileName = input[0],
                    Arguments = args
                };
                using (Process? program = Process.Start(startInfo))
                {
                    if (program is null)
                    {
                        Console.WriteLine($"Error: {input[0]} is not a valid executable");
                        return;
                    }
                    program.WaitForExit();
                }

                return;
            default:
                return;
        }
    }
}