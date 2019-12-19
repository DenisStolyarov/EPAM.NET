// <copyright file="SymmetricMatrix.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Result
{
    using System;

    /// <inheritdoc/>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class. 
        /// </summary>
        /// <param name="matrix">Universal type</param>
        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            this.MakeSymmetric(this.matrix);
        }

        /// <inheritdoc/>
        public override T this[int i, int j]
        {
            get
            {
                if (i > this.RowSize - 1
                || j > this.ColumnSize - 1
                || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.matrix[i, j];
            }

            set
            {
                if (i > this.RowSize - 1
                || j > this.ColumnSize - 1
                || i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.matrix[i, j] = value;

                this.OnChangeValue(this, new MatrixEventArgs<T>(i, j, value));

                if (i > j)
                {
                    this.MakeSymmetric(this.matrix, false);
                }
                else
                {
                    this.MakeSymmetric(this.matrix, true);
                }
            }
        }

        /// <summary>
        /// Makes two-dimensional array symmetrical
        /// </summary>
        /// <param name="other">Two-dimensional array</param>
        /// <param name="reverse">Up or down symmetry</param>
        /// <param name="startRow">Start matrix row</param>
        /// <param name="startColumn">Start matrix column</param>
        private void MakeSymmetric(T[,] other, bool reverse = true, int startRow = 0, int startColumn = 0)
        {
            if (startRow >= this.RowSize || startColumn >= this.ColumnSize)
            {
                throw new ArgumentException();
            }

            for (int i = startRow; i < other.GetUpperBound(0) + 1; i++)
            {
                for (int j = startColumn; j < other.GetUpperBound(0) + 1; j++)
                {
                    if (reverse)
                    {
                        other[j, i] = other[i, j];
                    }
                    else
                    {
                        other[i, j] = other[j, i];
                    }
                }
            }
        }
    }
}
