using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public partial class Program
{
    public static void RunC(string[] args, TextReader textReader, TextWriter textWriter)
    {
        var n = Convert.ToInt32(textReader.ReadLine());
        for (var i = 0; i < n; i++)
        {
            textWriter.WriteLine(ProblemCOneCase(textReader.ReadLine()!));
        }
    }

    public static string ProblemCOneCase(string input)
    {
        var result = ProblemC(input);
        return result is not null && result.Length > 0
            ? string.Join(' ', result)
            : "-";
    }

    private static readonly Regex Five = new("^[A-Z][0-9][0-9][A-Z][A-Z]");
    private static readonly Regex Four = new("^[A-Z][0-9][A-Z][A-Z]");

    private static string[]? ProblemC(string input)
    {
        if (input.Length == 0)
        {
            return Array.Empty<string>(); // match any pattern
        }

        return Five.IsMatch(input)
            ? Continuation(input, 5)
            : Four.IsMatch(input)
                ? Continuation(input, 4)
                : null; // none of patterns matches
    }

    private static string[]? Continuation(string input, int index)
    {
        var result = ProblemC(input[index..]);
        if (result is null)
        {
            return null;
        }

        var list = new List<string> { input[..index] };
        list.AddRange(result);
        return list.ToArray();
    }
}
