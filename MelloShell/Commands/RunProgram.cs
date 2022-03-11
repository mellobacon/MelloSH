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
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = input[0]
                };
                using (Process program = Process.Start(startInfo)!)
                {
                    program.WaitForExit();
                }

                return;
            default:
                return;
        }
    }
}