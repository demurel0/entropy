using Entropy.Cli;
using Entropy.Core;

namespace Entropy;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                PrintPassword(InteractivePrompt.Run());
            }
            else if (args.Contains("-h") || args.Contains("--help"))
            {
                HelpScreen.Show();
            }
            else
            {
                PrintPassword(ArgumentParser.Parse(args));
            }

            return 0;
        }
        catch (ArgumentException exception)
        {
            Terminal.WriteLine(Tone.Error, exception.Message);
            return 1;
        }
        catch (OperationCanceledException exception)
        {
            Console.WriteLine();
            Terminal.WriteLine(Tone.Warning, exception.Message);
            return 0;
        }
    }

    private static void PrintPassword(Options options)
    {
        var password = PasswordGenerator.Generate(options);

        Terminal.Write(Tone.Plain, "Generated password: ");
        Terminal.WriteLine(Tone.Password, password);
    }
}