using FluentAssertions;
using src;

namespace test;

public class DayOneTests
{
    [Fact]
    public void WhenTwoNumbers()
    {
        var value = CalibrationValueDetector.Detect("12");
        value.Should().Be(12);
    }

    [Fact]
    public void WhenTwoNumbersSeparatedByCharacter()
    {
        var value = CalibrationValueDetector.Detect("1a2");
        value.Should().Be(12);
    }

    [Fact]
    public void WhenTwoNumbersSeparatedByCharactersWithFirstAndLastCharacters()
    {
        var value = CalibrationValueDetector.Detect("a1a2a");
        value.Should().Be(12);
    }

    [Fact]
    public void WhenNoNumberAtAll()
    {
        var value = CalibrationValueDetector.Detect("abada");
        value.Should().Be(0);
    }

    [Fact]
    public void WhenOnlyOneNumber()
    {
        var value = CalibrationValueDetector.Detect("2");
        value.Should().Be(22);
    }

    [Theory]
    [InlineData("one", 11)]
    [InlineData("two", 22)]
    [InlineData("three", 33)]
    [InlineData("four", 44)]
    [InlineData("five", 55)]
    [InlineData("six", 66)]
    [InlineData("seven", 77)]
    [InlineData("eight", 88)]
    [InlineData("nine", 99)]
    public void WhenSingleSpelledOutNumber(string number, int expected)
    {
        var value = CalibrationValueDetector.Detect(number);
        value.Should().Be(expected);
    }

    [Fact]
    public void WhenFirstIntAndSecondSpelled()
    {
        var value = CalibrationValueDetector.Detect("1two");
        value.Should().Be(12);
    }
    

    [Fact]
    public void GivenMultipleLineLines()
    {
        var value =  CalibrationValueDetector.Detect("a23", "abc", "45");
        value.Should().Be(23 + 0 + 45);
    }
    
}