using System;
using NUnit.Framework;

namespace ExerciseLib.Tests
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(new double[] { 0.123, 0.456, 0.789 }, new double[] { 0.123, 0.456, 0.789 }, ExpectedResult = "0,246+0,912X^1+1,578X^2")]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 1, 0, 4 }, ExpectedResult = "1+1X^1+2X^2+4X^3")]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6, 0 }, ExpectedResult = "5+7X^1+9X^2")]
        [TestCase(new double[] { 0.5, 0.6 }, new double[] { 0.5, 0.6 }, ExpectedResult = "1+1,2X^1")]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = "0")]
        public string PolynomialSumTest(double[] array1, double[] array2)
        {
            return (new Polynomial(array1) + new Polynomial(array2)).ToString();
        }

        [TestCase(new double[] { 0.123, 0.456, 0.789 }, new double[] { -0.123, -0.456, -0.789 }, ExpectedResult = "0,246+0,912X^1+1,578X^2")]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 1, 0, 4 }, ExpectedResult = "1-1X^1+2X^2-4X^3")]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6, 0 }, ExpectedResult = "-3-3X^1-3X^2")]
        [TestCase(new double[] { 0.5, 0.6 }, new double[] { 0.5, 0.6 }, ExpectedResult = "0")]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = "0")]
        public string PolynomialSubtractionTest(double[] array1, double[] array2)
        {
            return (new Polynomial(array1) - new Polynomial(array2)).ToString();
        }

        [TestCase(new double[] { 0.123, 0.456, 0.789 }, new double[] { 0.123, 0.456, 0.789 }, ExpectedResult = "0,015+0,112X^1+0,402X^2+0,72X^3+0,623X^4")]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6, 0 }, ExpectedResult = "4+13X^1+28X^2+27X^3+18X^4")]
        [TestCase(new double[] { 0.5, 0.6 }, new double[] { 0.5, 0.6 }, ExpectedResult = "0,25+0,6X^1+0,36X^2")]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 1, 0, 4 }, ExpectedResult = "1X^1+6X^3+8X^5")]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = "0")]
        public string PolynomialMultiplicationTest(double[] array1, double[] array2)
        {
            return (new Polynomial(array1) * new Polynomial(array2)).ToString();
        }

        [TestCase(new double[] { 0.123, 0.456, 0.789 }, new double[] { 0.123, 0.456, 0.789 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.5, 0.6 }, new double[] { 0.5, 0.6 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 1, 0, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = true)]
        public bool PolynomialEqualTest(double[] array1, double[] array2)
        {
            return (new Polynomial(array1) == new Polynomial(array2));
        }

        [TestCase(new double[] { 0.123, 0.456, 0.789 }, new double[] { 0.123, 0.456, 0.789 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.5, 0.6 }, new double[] { 0.5, 0.6 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 0, 2 }, new double[] { 0, 1, 0, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = false)]
        public bool PolynomialNotEqualTest(double[] array1, double[] array2)
        {
            return (new Polynomial(array1) != new Polynomial(array2));
        }
        
        public void PolynomialExeptionTest()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));
            Assert.Throws<NullReferenceException>(() => new Polynomial(null));
            Assert.Throws<NullReferenceException>(() => new Polynomial());
        }
    }

    [TestFixture]
    public class JaggedArrayTest
    {
        private readonly int[][][] jaggedArrays = new int[][][]
        {
            new int [][]
            {
            new int[]{1,2,3},
            new int[]{6},
            new int[]{4,5}
            },
            // Result
            new int [][]
            {
            new int[]{1,2,3},
            new int[]{4,5},
            new int[]{6}
            },

            new int [][]
            {
            new int[]{1,2,3},
            new int[]{4,5},
            new int[]{6}
            },

            new int [][]
            {
            new int[]{1,2,3},
            new int[]{6},
            new int[]{4,5}
            },

            new int [][]
            {
            new int[]{6},
            new int[]{4,5},
            new int[]{1,2,3}
            },

            new int [][]
            {
            new int[]{6},
            new int[]{4,5},
            new int[]{1,2,3}
            },

            new int [][]
            {
            new int[]{4,5},
            new int[]{6},
            new int[]{1,2,3}
            },

            new int [][]
            {
            new int[]{4,5},
            new int[]{6},
            null
            },

            null
        }; 
        
        [Test]
        public void JaggedArraySort()
        {
            JaggedArray.BubbleSortAscending(jaggedArrays[0], JaggedArray.Max);
            Assert.AreEqual(jaggedArrays[0],jaggedArrays[1]);

            JaggedArray.BubbleSortAscending(jaggedArrays[0], JaggedArray.Min);
            Assert.AreEqual(jaggedArrays[0], jaggedArrays[2]);

            JaggedArray.BubbleSortAscending(jaggedArrays[0], JaggedArray.Sum);
            Assert.AreEqual(jaggedArrays[0], jaggedArrays[3]);

            JaggedArray.BubbleSortDescending(jaggedArrays[0], JaggedArray.Max);
            Assert.AreEqual(jaggedArrays[0], jaggedArrays[4]);

            JaggedArray.BubbleSortDescending(jaggedArrays[0], JaggedArray.Min);
            Assert.AreEqual(jaggedArrays[0], jaggedArrays[5]);

            JaggedArray.BubbleSortDescending(jaggedArrays[0], JaggedArray.Sum);
            Assert.AreEqual(jaggedArrays[0], jaggedArrays[6]);

            Assert.Throws<NullReferenceException>(() => JaggedArray.BubbleSortDescending(jaggedArrays[7], JaggedArray.Sum));
            Assert.Throws<NullReferenceException>(() => JaggedArray.BubbleSortDescending(jaggedArrays[7], JaggedArray.Sum));
        }
    }
}