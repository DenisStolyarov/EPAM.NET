// <copyright file="MatrixEventArgs.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Result
{
    using System;

    /// <summary>
    /// Represents a class containing matrix element change events
    /// </summary>
    /// <typeparam name="T">Universal type.</typeparam>
    public class MatrixEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArgs{T}"/> class. 
        /// </summary>
        /// <param name="row">Matrix row</param>
        /// <param name="column">Matrix column</param>
        /// <param name="value">Matrix value</param>
        public MatrixEventArgs(int row, int column, T value)
        {
            this.RowIndex = row;
            this.ColumnIndex = column;
            this.Value = value;
        }

        /// <summary>
        /// Gets row of matrix.
        /// </summary>
        public int RowIndex { get; private set; }

        /// <summary>
        /// Gets column of matrix.
        /// </summary>
        public int ColumnIndex { get; private set; }

        /// <summary>
        /// Gets value of matrix element.
        /// </summary>
        public T Value { get; private set; }
    }
}
