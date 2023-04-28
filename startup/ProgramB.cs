using System;
using System.IO;

public partial class Program
{
    public void RunB(string[] args, TextReader textReader, TextWriter textWriter)
    {
        var n = Convert.ToInt32(textReader.ReadLine());
        for (var i = 0; i < n; i++)
        {
            var parts = textReader.ReadLine()!.Split(' ');
            var ships = new int[5];
            for (int j = 0; j < 10; j++)
            {
                ships[int.Parse(parts[j])]++;
            }

            if (ships[1] != 4 || ships[2] != 3 || ships[3] != 2 || ships[4] != 1)
            {
                textWriter.WriteLine("NO");
            }
            else
            {
                textWriter.WriteLine("YES");
            }
        }
    }
}
