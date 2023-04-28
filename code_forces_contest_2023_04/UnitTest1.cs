using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace code_forces_contest_2023_04;

public class UnitTest1
{
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
        var sut = new startup.Program();
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
        var sut = new startup.Program();
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
        var output = startup.Program.ProblemCOneCase(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void SplitToSegments_3segments()
    {
        List<startup.Program.Data> list = new List<startup.Program.Data>()
        {
            new startup.Program.Data(1, 1), new startup.Program.Data(3, 3), new startup.Program.Data(5, 5),
        };
        var result = startup.Program.SplitToSegments(list);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void SplitToSegments_2segments()
    {
        List<startup.Program.Data> list = new List<startup.Program.Data>()
        {
            new startup.Program.Data(1, 1), new startup.Program.Data(2, 2), new startup.Program.Data(5, 5),
        };
        var result = startup.Program.SplitToSegments(list);
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
        var actualOutput = startup.Program.StepDImpl(input);
        Assert.Equal(expectedOutput, actualOutput);
    }

}
