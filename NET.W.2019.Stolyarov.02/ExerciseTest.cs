using System;
using ExerciseLib;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ExerciseTest
    {
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(0, 0, 1, 0, ExpectedResult = -1)]
        public int InsertNumberTest(int numberSource, int numberIn, int i, int j)
        {
            return Exercise.InsertNumber(numberSource, numberIn, i, j);
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumberTest(int numberIn)
        {
            return Exercise.FindNextBiggerNumber(numberIn);
        }

        [TestCase(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 70, 17 })]
        public int[] FilterDigitTest(int digit, int[] array)
        {
            return Exercise.FilterDigit(digit, array);
        }

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootTest(double number, int n, double epsilon)
        {
            return Exercise.FindNthRoot(number, n, epsilon);
        }

        [TestCase(8, 15, -7)]
        [TestCase(8, 15, -0.6)]
        public void FindNthRootExeptionTest(double number, int n, double epsilon)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Exercise.FindNthRoot(number, n, epsilon));
        }
    }
}