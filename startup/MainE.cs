using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    private static void RunMainE(string[] args, TextReader input, TextWriter output)
    {
        var s = input.ReadLine();
        int n = Convert.ToInt32(s);
        for (int i = 0; i < n; i++)
        {
            input.ReadLine(); // skip count
            var inputWord = input.ReadLine();
            string outputWord = MainE(inputWord!);
            output.WriteLine(outputWord);
        }
    }

    public static string MainE(string inputWord)
    {
        var list = inputWord.Split(' ').Select(int.Parse).ToList();
        var output = new List<char>();
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            var minItem = list.Select((value, index) => new { value, index }).MinBy(t => t.value);
            var minItemIndex = minItem!.index;
            if (minItemIndex <= list.Count / 2)
            {
                // rotate left
                for (int j = 0; j < minItemIndex; ++j)
                {
                    output.Add('L');
                    list.Add(list[0]);
                    list.RemoveAt(0);
                }

                output.Add('!');
                list.RemoveAt(0);
            }
            else
            {
                // rotate right
                for (int j = 0; j < (list.Count - minItemIndex); ++j)
                {
                    output.Add('R');
                    list.Insert(0, list[^1]);
                    list.RemoveAt(list.Count - 1);
                }

                output.Add('!');
                list.RemoveAt(0);
            }
        }

        var s = new string(output.ToArray());
        return s;
    }
}