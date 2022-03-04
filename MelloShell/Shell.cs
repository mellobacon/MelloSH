﻿using System.Globalization;
using System.Reflection;
using MelloShell.Commands;
using Newtonsoft.Json;

namespace MelloShell;

public static class Shell
{
    public static void Run()
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

    private static void Execute(string input)
    {
        // loook ik ik but hear me out every time i changed the current directory it would bug out and i dont have the patience rn alright. ill fix it later i promise
        const string path = @"D:\Coding\C#\MelloSH\MelloShell\Commands\Commands.json";
        if (!File.Exists(path))
        {
            Console.Error.Write("Error: Cannot parse commands");
            return;
        }

        //....dont ask. i dont know why im using this neither. maybe itll be more useful in the future who knows
        var commands = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
        if (commands is null)
        {
            Console.Error.Write("Error: Cannot parse commands");
            return;
        }

        string commandname = input.Split(" ")[0];
        string[] commandinput = input.Split(" ")[1..];
        if (commands.ContainsKey(commandname))
        {
            // reflection. fancy
            
            // get the command to run
            var commandtype = Type.GetType($"MelloShell.Commands.{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandname)}");
            // run the command and pass in any input if provided
            var command = (ICommand)Activator.CreateInstance(commandtype!)!;
            command.Run(commandinput);
        }
    }
}