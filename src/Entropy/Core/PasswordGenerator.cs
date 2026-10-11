using System.Security.Cryptography;

namespace Entropy.Core;

public static class PasswordGenerator
{
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Digits = "0123456789";
    private const string Special = "!@#$%^&*()_+-=";

    public static string Generate(Options options)
    {
        if (options.Length is < Options.MinLength or > Options.MaxLength)
        {
            throw new ArgumentException($"Length must be between {Options.MinLength} and {Options.MaxLength}.");
        }

        var alphabet = BuildAlphabet(options);
        if (alphabet.Length == 0)
        {
            throw new ArgumentException("You cannot exclude all character sets at the same time.");
        }

        return RandomNumberGenerator.GetString(alphabet, options.Length);
    }

    private static string BuildAlphabet(Options options) => string.Concat(
        options.UseLower ? Lower : string.Empty,
        options.UseUpper ? Upper : string.Empty,
        options.UseDigits ? Digits : string.Empty,
        options.UseSpecial ? Special : string.Empty);
}