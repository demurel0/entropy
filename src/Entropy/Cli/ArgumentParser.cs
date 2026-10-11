using Entropy.Core;

namespace Entropy.Cli;

internal static class ArgumentParser
{
    public static Options Parse(string[] args)
    {
        var options = new Options();
        
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--length":
                    if (++i >= args.Length || !int.TryParse(args[i], out var length))
                    {
                        throw new ArgumentException("The '--length' flag must be followed by a number.");
                    }
                    
                    options.Length = length;
                    break;
                
                case "-l" or "--no-lower":
                    options.UseLower = false;
                    break;
                
                case "-u" or "--no-upper":
                    options.UseUpper = false;
                    break;
                
                case "-d" or "--no-digits":
                    options.UseDigits = false;
                    break;
                
                case "-s" or "--no-special":
                    options.UseSpecial = false;
                    break;
                
                default:
                    if (!int.TryParse(args[i], out var number))
                    {
                        throw new ArgumentException($"Unknown argument: '{args[i]}'. Use '-h' or '--help' for help.");
                    }
                    
                    options.Length = number;
                    break;
            }
        }
        
        return options;
    }
}