namespace Entropy.Cli;

internal enum Tone
{
    Plain,
    Muted,
    Heading,
    Command,
    Password,
    Input,
    Warning,
    Error,
}

internal static class Terminal
{
    public static void Write(Tone tone, string text)
    {
        var color = ColorOf(tone);
        if (color is not null)
        {
            Console.ForegroundColor = color.Value;
        }

        Console.Write(text);
        Console.ResetColor();
    }

    public static void WriteLine(Tone tone, string text)
    {
        Write(tone, text);
        Console.WriteLine();
    }

    private static ConsoleColor? ColorOf(Tone tone) => tone switch
    {
        Tone.Muted => ConsoleColor.DarkGray,
        Tone.Heading => ConsoleColor.Blue,
        Tone.Command or Tone.Password => ConsoleColor.Green,
        Tone.Input => ConsoleColor.Cyan,
        Tone.Warning => ConsoleColor.Yellow,
        Tone.Error => ConsoleColor.Red,
        _ => null,
    };
}