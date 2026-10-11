using Entropy.Core;

namespace Entropy.Cli;

internal static class InteractivePrompt
{
    public static Options Run()
    {
        ShowKeyBar();
        
        var options = new Options
        {
            Length = AskLength(),
            UseLower = AskYesNo("Include lowercase letters?"),
            UseUpper = AskYesNo("Include uppercase letters?"),
            UseDigits = AskYesNo("Include digits?"),
        };
        
        if (!(options.UseLower || options.UseUpper || options.UseDigits))
        {
            Terminal.WriteLine(Tone.Warning, "Only special characters remain.");
            options.UseSpecial = true;
        }
        else
        {
            options.UseSpecial = AskYesNo("Include special characters?");
        }
        
        Console.WriteLine();
        return options;
    }
    
    private static void ShowKeyBar()
    {
        Terminal.WriteLine(Tone.Muted, "← → length  |  Y/n answer  |  Enter confirm  |  Q quit");
        Console.WriteLine();
    }
    
    private static int AskLength()
    {
        var length = Options.DefaultLength;
        DrawLength(length);
        
        while (true)
        {
            var keyInfo = ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine();
                    return length;

                case ConsoleKey.RightArrow when length < Options.MaxLength:
                    DrawLength(++length);
                    break;

                case ConsoleKey.LeftArrow when length > Options.MinLength:
                    DrawLength(--length);
                    break;
            }
        }
    }
    
    private static void DrawLength(int length)
    {
        Console.Write('\r');
        Terminal.Write(Tone.Plain, "How long should the password be? ");
        Terminal.Write(Tone.Input, length.ToString("D2"));
    }
    
    private static bool AskYesNo(string question)
    {
        Terminal.Write(Tone.Plain, $"{question} ");
        
        while (true)
        {
            var keyInfo = ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    Terminal.WriteLine(Tone.Input, "Y");
                    return true;
                
                case ConsoleKey.Y:
                    Terminal.WriteLine(Tone.Input, keyInfo.KeyChar.ToString());
                    return true;

                case ConsoleKey.N:
                    Terminal.WriteLine(Tone.Input, keyInfo.KeyChar.ToString());
                    return false;
            }
        }
    }
    
    private static ConsoleKeyInfo ReadKey()
    {
        var keyInfo = Console.ReadKey(intercept: true);
        
        if (keyInfo.Key == ConsoleKey.Q)
        {
            throw new OperationCanceledException("Cancelled.");
        }
        
        return keyInfo;
    }
}