using System;
using System.IO;

public partial class Program
{
    public void RunA(string[] args, TextReader textReader, TextWriter textWriter)
    {
        var n = Convert.ToInt32(textReader.ReadLine());
        for (var i = 0; i < n; i++)
        {
            var span = textReader.ReadLine().AsSpan();
            var p = span.IndexOf(' ');
            var firstValue = int.Parse(span[..p]);
            var secondValue = int.Parse(span[(p + 1)..]);
            var sum = firstValue + secondValue;
            textWriter.WriteLine(sum.ToString());
        }
    }
}
