using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    private static void RunMainC(string[] args, TextReader input, TextWriter output)
    {
        var s = input.ReadLine();
        int n = Convert.ToInt32(s);
        for (int i = 0; i < n; i++)
        {
            var n2 = input.ReadLine(); // skip it
            var inputWord = input.ReadLine();
            (string, int) outputWord = MainC(inputWord!);
            output.WriteLine(outputWord.Item2);
            output.WriteLine(outputWord.Item1);
        }
    }

    private enum StateC
    {
        None = 0,
        ReadingFirstItem, // определяем стартовую точку
        ReadingSecondItem, // определяем, есть ли последовательность и какого она направления
        ReadingNextItem // проверяем, укладывается ли следующий член в эту последовательность.
    }

    public static (string, int) MainC(string inputWord)
    {
        var list = inputWord.Split(' ').Select(int.Parse).ToList();
        StateC state = StateC.ReadingFirstItem;
        int initial = int.MinValue;
        int prev = int.MinValue;
        int c = 0;
        List<(int, int)> outputList = new();
        foreach (var i in list)
        {
            switch (state)
            {
                case StateC.ReadingFirstItem:
                    prev = i;
                    initial = i;
                    state = StateC.ReadingSecondItem;
                    break;
                case StateC.ReadingSecondItem:
                    if (i == prev + 1)
                    {
                        c = 1;
                        state = StateC.ReadingNextItem;
                    }
                    else if (i == prev - 1)
                    {
                        c = -1;
                        state = StateC.ReadingNextItem;
                    }
                    else
                    {
                        outputList.Add((initial, 0));
                        initial = i;
                        state = StateC.ReadingSecondItem;
                    }

                    prev = i;

                    break;
                case StateC.ReadingNextItem:
                    if (i == prev + 1 && c > 0)
                    {
                        c++;
                    }
                    else if (i == prev - 1 && c < 0)
                    {
                        c--;
                    }
                    else
                    {
                        outputList.Add((initial, c));
                        initial = i;
                        state = StateC.ReadingSecondItem;
                    }

                    prev = i;

                    break;
            }
        }

        outputList.Add((initial, state switch
        {
            StateC.ReadingSecondItem => 0,
            StateC.ReadingNextItem => c,
            _ => throw new ArgumentOutOfRangeException()
        }));

        var selectMany = outputList.SelectMany(tuple => new[] { tuple.Item1, tuple.Item2 }).ToList();
        return (string.Join(' ', selectMany), selectMany.Count);
    }
}