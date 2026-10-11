using Entropy.Core;

namespace Entropy.Cli;

internal static class HelpScreen
{
    private const string Logo =
        """
        ┌──────────────────────┐
        │  ••••••••••          │
        └──────────────────────┘
        """;
    
    private static readonly (string Flag, string Description)[] Flags =
    [
        ("--length <number>", $"Password length ({Options.MinLength}–{Options.MaxLength}), default {Options.DefaultLength}"),
        ("-l, --no-lower", "Exclude lowercase letters"),
        ("-u, --no-upper", "Exclude uppercase letters"),
        ("-d, --no-digits", "Exclude digits"),
        ("-s, --no-special", "Exclude special characters"),
        ("-h, --help", "Show this help"),
    ];
    
    public static void Show()
    {
        Terminal.WriteLine(Tone.Heading, Logo);
        Console.WriteLine();
        
        Terminal.WriteLine(Tone.Heading, "USAGE");
        Terminal.Write(Tone.Command, "  Entropy");
        Terminal.WriteLine(Tone.Muted, " [length] [options]");
        Console.WriteLine();
        
        Terminal.WriteLine(Tone.Heading, "OPTIONS");
        foreach (var (flag, description) in Flags)
        {
            Terminal.Write(Tone.Command, $"  {flag,-18}");
            Terminal.WriteLine(Tone.Plain, description);
        }
    }
}