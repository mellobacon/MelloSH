using System.Reflection;
using MelloShell.Commands;

namespace MelloShell;

public class Shell
{
    private readonly Dictionary<string, Type>? _commands = new ();
    public Shell()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!type.GetInterfaces().Contains(typeof(ICommand))) continue;
            var commandtype = type.GetCustomAttribute<Command>()!;
            _commands!.Add(commandtype.Commandname, type);
        }
    }
    public void Run()
    {
        const string prompt = "MelloShell - $";
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input is "exit") break;
            Execute(input);
        }
    }

    private void Execute(string input)
    {
        string[] args = input.Split();
        string commandname = args[0];
        args = args[1..];
        if (_commands is null)
        {
            Console.Error.WriteLine("Error: Could not load commands.");
            return;
        }
        if (_commands.ContainsKey(commandname))
        {
            var command = (ICommand)Activator.CreateInstance(_commands[commandname])!;
            command.Run(args);
        }
    }
}