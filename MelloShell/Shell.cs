﻿using System.Reflection;
using System.Text;
using MelloShell.Commands;

namespace MelloShell;

public class Shell
{
    private readonly Dictionary<string, Type> _commands = new ();
    public Shell()
    {
        // Commands are stored in the "Commands" directory.
        // Iterate through the project, get any valid command files, and cache the command info
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            // A valid command file will have the ICommand interface
            if (!type.GetInterfaces().Contains(typeof(ICommand))) continue;
            
            // Get and store the command info
            var commandtype = type.GetCustomAttribute<CommandAttribute>()!;
            _commands.Add(commandtype.Commandname, type);
            if (commandtype.Aliases != null)
            {
                foreach (var alias in commandtype.Aliases)
                {
                    _commands.Add(alias, type);
                }
            }
        }
        // Set the directory to the default folder that other shells default to apparently
        Directory.SetCurrentDirectory(@$"C:\Users\{Environment.UserName}");
    }
    public void Run()
    {
        while (true)
        {
            Console.Write($"MelloShell[{Directory.GetCurrentDirectory()}]> ");
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input is "exit") break;
            
            Execute(input);
        }
    }
    
    private void Execute(string input)
    {
        string[] args = input.Split(null, 2);
        string commandname = args[0];
        args = args.Length == 1 ? Array.Empty<string>() : GetArgs(args[1]);

        if (_commands.ContainsKey(commandname))
        {
            var command = (ICommand)Activator.CreateInstance(_commands[commandname])!;
            command.Run(args);
            return;
        }
        Console.Error.WriteLine($"Error: {commandname} is not a valid command");
    }

    private static string[] GetArgs(string args)
    {
        var parsedargs = new List<string>();
        var arg = new StringBuilder();
        var quoted = false;
        foreach (var character in args)
        {
            switch (character)
            {
                case ' ' when quoted:
                    arg.Append(' ');
                    break;
                case ' ':
                    parsedargs.Add(arg.ToString());
                    arg.Clear();
                    break;
                case '"':
                    quoted = !quoted;
                    break;
                default:
                    arg.Append(character);
                    break;
            }
        }

        if (arg.Length > 0)
        {
            parsedargs.Add(arg.ToString());
        }

        return parsedargs.ToArray();
    }
}
