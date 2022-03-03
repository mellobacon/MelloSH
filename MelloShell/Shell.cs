using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;

namespace MelloShell;

public class Shell
{
    public void Run()
    {
        const string prompt = "MelloShell - $ ";
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

        string command = input.Split(" ")[0];
        string[] commandinput = input.Split(" ")[1..];
        if (commands.ContainsKey(command))
        {
            // reflection. fancy
            
            // get the command to run
            var commandtype = Type.GetType($"MelloShell.Commands.{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(command)}");
            // get the constructor info even tho its nonexistent atm
            ConstructorInfo? ctorinfo = commandtype?.GetConstructor(Type.EmptyTypes);
            object? ctor = ctorinfo?.Invoke(Array.Empty<object>());
            // run the command and pass in any input if provided
            MethodInfo? process = commandtype?.GetMethod("Run");
            process?.Invoke(ctor, new object?[] { commandinput });
        }
    }
}