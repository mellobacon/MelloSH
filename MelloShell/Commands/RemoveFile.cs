﻿namespace MelloShell.Commands;

[CommandAttribute("rm")]
public class RemoveFile : ICommand
{
    public void Run(string[] input)
    {
        var path = Directory.GetCurrentDirectory();
        switch (input.Length)
        {
            case > 0:
                foreach (var filename in input)
                {
                    if (File.Exists(filename))
                    {
                        File.Delete($@"{path}\{filename}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {filename} does not exist");
                    }
                }

                return;
            default:
                Console.WriteLine("Error: args not valid or something...idk");
                return;
        }
    }
}