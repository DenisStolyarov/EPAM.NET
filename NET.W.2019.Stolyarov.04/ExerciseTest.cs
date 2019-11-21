using NUnit.Framework;

namespace ExerciseLib.Tests
{
    [TestFixture]
    public class ExerciseTests
    {
        [TestCase(new int[] { 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, -5 }, ExpectedResult = 5)]
        [TestCase(new int[] { -10, -20, 30 }, ExpectedResult = 10)]
        [TestCase(new int[] { -10, 6, -8, 12 }, ExpectedResult = 2)]
        public int BinaryGcdTest(int[] array)
        {
            return Exercise.BinaryGcd(array);
        }

        [TestCase(new int[] { 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, -5 }, ExpectedResult = 5)]
        [TestCase(new int[] { -10, -20, 30 }, ExpectedResult = 10)]
        [TestCase(new int[] { -10, 6, -8, 12 }, ExpectedResult = 2)]
        public int EuclidGcdTest(int[] array)
        {
            return Exercise.EuclidGcd(array);
        }

        [TestCase(-255.255, ExpectedResult =
        "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult =
        "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult =
        "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult =
        "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult =
        "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult =
        "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult =
        "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult =
        "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult =
        "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult =
        "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult =
        "0000000000000000000000000000000000000000000000000000000000000000")]
        public string BinaryFormatTest(double number)
        {
            return number.BinaryFormat();
        }
    }
}