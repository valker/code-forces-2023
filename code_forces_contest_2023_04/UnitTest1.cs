using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Xunit;

namespace code_forces_contest_2023_04;

public class UnitTest1
{

    [Theory]
    [InlineData("6 4 3 1 2 7","LLL!!R!R!L!!")]
    [InlineData("50 9 22 5 3 21 7 16 27 6","LLLL!R!LLLL!RRR!LLL!LL!R!R!!!")]
    public void MainE(string input, string output)
    {
        var o = Program.MainE(input);
        Assert.Equal(output, o);
    }
    
    [Theory]
    [InlineData("otLLLrRuEe256LLLN", "route\n256")]
    [InlineData("LRLUUDE", "")]
    [InlineData("itisatest", "itisatest")]
    [InlineData("abNcdLLLeUfNxNx", "af\nx\nxb\necd")]
    [InlineData("7", "7")]
    [InlineData("g", "g")]
    [InlineData("v", "v")]
    [InlineData("N", "\n")]
    [InlineData("88Rv", "88v")]
    //11
    [InlineData("D", "")]
    [InlineData("BEBBUjL", "j")]
    [InlineData("c3DhU4RLEU", "c3h4")]
    [InlineData("kki", "kki")]
    [InlineData("ED", "")]
    [InlineData("Rt08ELLgL", "tg08")]
    [InlineData("BNNuLdtn", "\n\ndtnu")]
    [InlineData("xRRgD6N", "xg6\n")]
    [InlineData("tR", "t")]
    [InlineData("N4Ruk", "\n4uk")]
    public void MainD(string input, string output)
    {
        var o = Program.MainD(input);
        Assert.Equal(output, o);
    }
    
    [Theory]
    [MemberData(nameof(TestsForMainD2))]
    public void MainD2(string input, string output)
    {
        var o = Program.MainD(input);
        Assert.Equal(output, o);
    }

    public static IEnumerable<object[]> TestsForMainD2()
    {
        using var sr1 = new StreamReader("12");
        using var sr2 = new StreamReader("12.a");
        sr1.ReadLine();
        while (!sr1.EndOfStream)
        {
            var l1 = sr1.ReadLine();

            List<string> list = new();
            while (true)
            {
                var l2 = sr2.ReadLine();
                if (l2 == "-")
                {
                    break;
                }
                list.Add(l2!);
            }

            yield return new object[] { l1!, string.Join('\n', list) };
        }
    }
    
    [Theory]
    [InlineData("3 2 1 0 -1 0 6 6 7","3 -4 0 0 6 0 6 1")]
    [InlineData("1000","1000 0")]
    [InlineData("1 2 3 4 5 6 7","1 6")]
    [InlineData("1 3 5 7 9 11 13","1 0 3 0 5 0 7 0 9 0 11 0 13 0")]
    [InlineData("100 101 102 103 19 20 21 22 42 41 40","100 3 19 3 42 -2")]
    public void MainC(string input, string expectedOutput)
    {
        var output = Program.MainC(input);
        Assert.Equal(expectedOutput, output.Item1);
    }
    
    [Theory]
    [InlineData("3 0 1 0 5 2 2 6 4 3 5 1 3 2 0 6 0","4")]
    [InlineData("3 1 1 1 2 4 2 4 0 2 0","3")]
    [InlineData("1 0 2 1 1","2")]
    [InlineData("1 0","1")]
    public void MainB(string input, string expectedOutput)
    {
        var output = Program.MainB(input);
        Assert.Equal(expectedOutput, output);
    }
    
    [Theory]
    [InlineData("cat", "cats")]
    [InlineData("tax", "taxes")]
    [InlineData("city", "cities")]
    [InlineData("counterpunch", "counterpunches")]
    public void MainA(string input, string expectedOutput)
    {
        Assert.Equal(expectedOutput, Program.MainA(input));
    }
    
    [Theory]
    [InlineData(@"1
1 1", @"2
")]
    [InlineData(@"2
1 1
2 2", @"2
4
")]
    public void ProblemA(string input, string expectedOutput)
    {
        var sut = new Program();
        StringBuilder sb = new();
        sut.RunA(Array.Empty<string>(), new StringReader(input), new StringWriter(sb));
        Assert.Equal(expectedOutput, sb.ToString());
    }

    [Theory]
    [InlineData(@"5
2 1 3 1 2 3 1 1 4 2
1 1 1 2 2 2 3 3 3 4
1 1 1 1 2 2 2 3 3 4
4 3 3 2 2 2 1 1 1 1
4 4 4 4 4 4 4 4 4 4",@"YES
NO
YES
YES
NO
")]
    public void ProblemB(string input, string expectedOutput)
    {
        var sut = new Program();
        StringBuilder sb = new();
        sut.RunB(Array.Empty<string>(), new StringReader(input), new StringWriter(sb));
        Assert.Equal(expectedOutput, sb.ToString());
    }
    [Theory]
    [InlineData("R48FAO00OOO0OOA99OKA99OK","R48FA O00OO O0OO A99OK A99OK")]
    [InlineData("R48FAO00OOO0OOA99OKA99O","-")]
    [InlineData("A9PQ","A9PQ")]
    [InlineData("A9PQA","-")]
    [InlineData("A99AAA99AAA99AAA99AA","A99AA A99AA A99AA A99AA")]
    [InlineData("AP9QA","-")]
    public void ProblemC(string input, string expectedOutput)
    {
        var output = Program.ProblemCOneCase(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void SplitToSegments_3segments()
    {
        List<Program.Data> list = new List<Program.Data>()
        {
            new Program.Data(1, 1), new Program.Data(3, 3), new Program.Data(5, 5),
        };
        var result = Program.SplitToSegments(list);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void SplitToSegments_2segments()
    {
        List<Program.Data> list = new List<Program.Data>()
        {
            new Program.Data(1, 1), new Program.Data(2, 2), new Program.Data(5, 5),
        };
        var result = Program.SplitToSegments(list);
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[0].Count);
        Assert.Equal(1, result[1].Count);

    }

    [Theory]
    [InlineData("20 10 20 30", "2 1 2 4")]
    [InlineData("5 7 6", "1 1 1")]
    [InlineData("6 3 4 3 1", "5 2 2 2 1")]
    [InlineData("200 10 100 11 200", "4 1 3 1 4")]
    [InlineData("1000000000", "1")]
    [InlineData("13 8 12 1 7 10 1 8 10 2 17", "9 4 9 1 4 7 1 4 7 1 11")]
    public void StepDImpl(string input, string expectedOutput)
    {
        var actualOutput = Program.StepDImpl(input);
        Assert.Equal(expectedOutput, actualOutput);
    }

}
