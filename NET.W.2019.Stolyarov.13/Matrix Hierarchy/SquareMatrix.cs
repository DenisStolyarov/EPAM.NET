// <copyright file="SquareMatrix.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Result
{
    using System;

    /// <inheritdoc/>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class. 
        /// </summary>
        /// <param name="matrix">Universal type</param>
        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            if (this.ColumnSize != this.RowSize)
            {
                throw new ArgumentException(nameof(matrix));
            }
        }
    }
}
