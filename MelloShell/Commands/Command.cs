namespace MelloShell.Commands;

public class Command : Attribute
{
    public readonly string Commandname;
    public string[]? Aliases;
    public Command(string name)
    {
        Commandname = name;
    }
}