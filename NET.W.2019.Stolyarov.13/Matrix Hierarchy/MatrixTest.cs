using System;
using NUnit.Framework;
using Result;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixTest
    {
        private int[,] IntegerMatrix = new int[3, 3]
            {
                {1, 2, 3 },
                {4, 1, 0 },
                {3, 0, 1 }
            };

        private string[,] StringMatrix = new string[3, 3]
            {
                {"a", "b", "c" },
                {"a", "b", "c"},
                {"a", "b", "c"}
            };

        private string[,] DiagonalMatrix = new string[3, 3]
            {
                {"a", null, null },
                {null, "b", null },
                {null, null, "c" }
            };

        private string[,] SymmetricMatrix = new string[3, 3]
            {
                {"a", "b", "c" },
                {"b", "b", "c" },
                {"c", "c", "c" }
            };

        private int[,] SumSquaresMatrix = new int[3, 3]
            {
                {2, 4, 6 },
                {8, 2, 0 },
                {6, 0, 2 }
            };

        private int[,] SumSquareDiagonalMatrix = new int[3, 3]
            {
                {2, 2, 3 },
                {4, 2, 0 },
                {3, 0, 2 }
            };

        private int[,] SumSquareSymmetricMatrix = new int[3, 3]
            {
                {2, 4, 6 },
                {6, 2, 0 },
                {6, 0, 2 }
            };

        private int[,] EmptyMatrix = new int[0, 0] { };

        private int[,] NonSquareMatrix = new int[3, 2]
            {
                {2, 4},
                {6, 2},
                {6, 0}
            };

        [Test]
        public void CheckMatrixConversion()
        {
            Assert.AreEqual(new SymmetricMatrix<string>(StringMatrix).ToString(), new Matrix<string>(SymmetricMatrix).ToString());
            Assert.AreEqual(new DiagonalMatrix<string>(StringMatrix).ToString(), new Matrix<string>(DiagonalMatrix).ToString());
        }

        [Test]
        public void CheckMatrixSum()
        {
            Assert.AreEqual((new SquareMatrix<int>(IntegerMatrix).MatrixSum(new SquareMatrix<int>(IntegerMatrix)).ToString()), new Matrix<int>(SumSquaresMatrix).ToString());
            Assert.AreEqual((new SquareMatrix<int>(IntegerMatrix).MatrixSum(new DiagonalMatrix<int>(IntegerMatrix)).ToString()), new Matrix<int>(SumSquareDiagonalMatrix).ToString());
            Assert.AreEqual((new SquareMatrix<int>(IntegerMatrix).MatrixSum(new SymmetricMatrix<int>(IntegerMatrix)).ToString()), new Matrix<int>(SumSquareSymmetricMatrix).ToString());
        }

        [Test]
        public void ErrorMatrix()
        {
            Assert.Throws<ArgumentNullException>(() => new Matrix<string>(null));
            Assert.Throws<ArgumentException>(() => new Matrix<int>(EmptyMatrix));
            Assert.Throws<ArithmeticException>(() => new SquareMatrix<string>(StringMatrix).MatrixSum(new SquareMatrix<string>(StringMatrix)));
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(NonSquareMatrix));
        }
    }
}