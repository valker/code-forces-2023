using System;
using System.IO;
using System.Text.RegularExpressions;

public partial class Program
{
    private static void RunMainA(string[] args, TextReader input, TextWriter output)
    {
        var s = input.ReadLine();
        int n = Convert.ToInt32(s);
        for (int i = 0; i < n; i++)
        {
            var inputWord = input.ReadLine();
            string outputWord = MainA(inputWord!);
            output.WriteLine(outputWord);
        }
    }

    private static readonly Regex Rule1 = new Regex(@".*(s|sh|ch|x|z)$");
    private static readonly Regex Rule2 = new Regex(@".*[bcdfghjklmnpqrstvwxz]y$");

    public static string MainA(string inputWord)
    {
        if (Rule1.IsMatch(inputWord))
        {
            return inputWord + "es";
        }
        else if (Rule2.IsMatch(inputWord))
        {
            return inputWord[..^1] + "ies";
        }
        else
        {
            return inputWord + "s";
        }
    }
}