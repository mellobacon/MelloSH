namespace MelloShell.Commands;

public class CommandAttribute : Attribute
{
    public readonly string Commandname;
    public string[]? Aliases;
    public CommandAttribute(string name)
    {
        Commandname = name;
    }
}