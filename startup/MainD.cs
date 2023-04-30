using System;
using System.Collections.Generic;
using System.IO;

public partial class Program
{
    private static void RunMainD(string[] args, TextReader input, TextWriter output)
    {
        var s = input.ReadLine();
        int n = Convert.ToInt32(s);
        for (int i = 0; i < n; i++)
        {
            var inputWord = input.ReadLine();
            string outputWord = MainD(inputWord!);
            output.WriteLine(outputWord);
            output.WriteLine('-');
        }
    }

    public static string MainD(string inputWord)
    {
        List<string> outputBuffer = new() { "" };
        int currentLine = 0;
        int currentColumn = 0;
        foreach (char c in inputWord)
        {
            switch (c)
            {
                case 'L':
                    currentColumn--;
                    if (currentColumn < 0) currentColumn = 0;
                    break;
                case 'R':
                    currentColumn++;
                    if (currentColumn > outputBuffer[currentLine].Length)
                    {
                        currentColumn = outputBuffer[currentLine].Length;
                    }

                    break;
                case 'U':
                    if (currentLine == 0)
                    {
                    }
                    else
                    {
                        currentLine--;
                        if (currentColumn > outputBuffer[currentLine].Length)
                        {
                            currentColumn = outputBuffer[currentLine].Length;
                        }
                    }

                    break;
                case 'D':
                    if (currentLine == outputBuffer.Count - 1)
                    {
                    }
                    else
                    {
                        currentLine++;
                        if (currentColumn > outputBuffer[currentLine].Length)
                        {
                            currentColumn = outputBuffer[currentLine].Length;
                        }
                    }

                    break;
                case 'B':
                    currentColumn = 0;
                    break;
                case 'E':
                    currentColumn = outputBuffer[currentLine].Length;
                    break;
                case 'N':
                    var newLine1 = outputBuffer[currentLine].Substring(0, currentColumn);
                    var newLine2 = outputBuffer[currentLine].Substring(currentColumn);
                    outputBuffer[currentLine] = newLine1;
                    currentLine++;
                    outputBuffer.Insert(currentLine, newLine2);
                    currentColumn = 0;
                    break;
                default:
                    outputBuffer[currentLine] = outputBuffer[currentLine].Insert(currentColumn, c.ToString());
                    currentColumn++;
                    break;
            }
        }

        return string.Join("\n", outputBuffer);
    }
}