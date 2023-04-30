using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    private static void RunMainB(string[] args, TextReader input, TextWriter output)
    {
        var s = input.ReadLine();
        int n = Convert.ToInt32(s);
        for (int i = 0; i < n; i++)
        {
            var n2 = input.ReadLine(); // skip it
            var inputWord = input.ReadLine();
            string outputWord = MainB(inputWord!);
            output.WriteLine(outputWord);
        }
    }

    private enum State
    {
        None = 0,
        ReadingNumber,
        ReadingCountOfChildren,
        ReadingChildren
    }

    public static string MainB(string inputWord)
    {
        var list = inputWord.Split(' ').Select(int.Parse).ToList();
        Dictionary<int, bool> dict = new();
        State state = State.ReadingNumber;
        int childrenToRead = 0;
        foreach (var i in list)
        {
            if (state == State.ReadingChildren && childrenToRead == 0)
            {
                state = State.ReadingNumber;
            }

            switch (state)
            {
                case State.ReadingNumber:
                    dict.TryAdd(i, true);
                    state = State.ReadingCountOfChildren;
                    break;
                case State.ReadingCountOfChildren:
                    childrenToRead = i;
                    state = State.ReadingChildren;
                    break;
                case State.ReadingChildren:
                    dict[i] = false;
                    childrenToRead--;
                    break;
            }
        }

        return dict.First(pair => pair.Value).Key.ToString();
    }
}