// <copyright file="DiagonalMatrix.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Result
{
    using System;

    /// <inheritdoc/>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class. 
        /// </summary>
        /// <param name="matrix">Universal type</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            for (int i = 0; i < this.RowSize; i++)
            {
                for (int j = 0; j < this.ColumnSize; j++)
                {
                    if (i != j)
                    {
                        this.matrix[i, j] = default(T);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override T this[int i, int j]
        {
            get => base[i, j];

            set
            {
                if (i > this.RowSize - 1
                || j > this.ColumnSize - 1
                || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (i == j)
                {
                    this.OnChangeValue(this, new MatrixEventArgs<T>(i, j, value));
                    this.matrix[i, j] = value;
                }
            }
        }
    }
}
