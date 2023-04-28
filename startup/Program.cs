using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        RunD(args, Console.In, Console.Out);
    }

    private static void RunD(string[] args, TextReader textReader, TextWriter textWriter)
    {
        var n = Convert.ToInt32(textReader.ReadLine());
        for (var i = 0; i < n; i++)
        {
            StepD(textReader, textWriter);
        }
    }

    public record Data(int Index, int Value, int Assessment = -1)
    {
        public int Assessment { get; set; } = Assessment;
    }

    private static void StepD(TextReader textReader, TextWriter textWriter)
    {
        var n = Convert.ToInt32(textReader.ReadLine()); // skip
        var input = textReader.ReadLine()!;
        var output = StepDImpl(input);
        textWriter.WriteLine(output);
    }

    public static string StepDImpl(string input)
    {
        var list = input.Split(' ')
            .Select((s, i) => new Data(i, int.Parse(s)))
            .OrderBy(i => i.Value)
            .ToList();
        var segments = SplitToSegments(list);
        var assessment = 1;
        foreach (var segment in segments)
        {
            foreach (var data in segment)
            {
                data.Assessment = assessment;
            }

            assessment += segment.Count;
        }

        var output = string.Join(' ', segments
            .SelectMany(data => data)
            .OrderBy(data => data.Index)
            .Select(data => data.Assessment));
        return output;
    }

    public static List<List<Data>> SplitToSegments(List<Data> list)
    {
        List<List<Data>> result = new();
        using IEnumerator<Data> enumerator = list.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return result;
        }

        bool moved = true;
        while (moved)
        {
            List<Data> segment = new();
            int current;
            do
            {
                current = enumerator.Current.Value;
                segment.Add(enumerator.Current);
            } while ((moved = enumerator.MoveNext()) && (enumerator.Current.Value - current) <= 1);

            result.Add(segment);
        }

        return result;
    }
}
