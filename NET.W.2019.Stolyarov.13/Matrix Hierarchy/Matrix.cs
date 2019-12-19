// <copyright file="Matrix.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Result
{
    using System;
    using System.Linq.Expressions;
    using System.Text;

    /// <summary>
    /// Provides tools for working with matrices
    /// </summary>
    /// <typeparam name="T">Universal type</typeparam>
    public class Matrix<T>
    {
        /// <summary>
        /// Event Handler
        /// </summary>
        public EventHandler<MatrixEventArgs<T>> Handler;

        /// <summary>
        /// Two-dimensional array
        /// </summary>
        protected T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class. 
        /// </summary>
        /// <param name="matrix">Two-dimensional array</param>
        public Matrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int rowSize = matrix.GetUpperBound(0) + 1;
            int columnSize = matrix.GetUpperBound(1) + 1;

            if (rowSize == 0 || columnSize == 0)
            {
                throw new ArgumentException(nameof(matrix));
            }

            this.RowSize = rowSize;
            this.ColumnSize = columnSize;
            this.matrix = this.CloneMatrix(matrix);
        }

        /// <summary>
        /// Gets size of columns in matrix
        /// </summary>
        protected int ColumnSize { get; }

        /// <summary>
        /// Gets size of rows in matrix
        /// </summary>
        protected int RowSize { get; }
        
        /// <summary>
        /// Gets Matrix value
        /// </summary>
        /// <param name="i">Row number</param>
        /// <param name="j">Column number</param>
        /// <returns>Matrix value</returns>
        public virtual T this[int i, int j]
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

                this.OnChangeValue(this, new MatrixEventArgs<T>(i, j, value));
                this.matrix[i, j] = value;
            }
        }

        /// <summary>
        /// Makes copy of Matrix
        /// </summary>
        /// <param name="other">Two-dimensional array</param>
        /// <returns>Copy of array</returns>
        public T[,] CloneMatrix(T[,] other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            T[,] result = new T[this.RowSize, this.ColumnSize];

            for (int i = 0; i < other.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < other.GetUpperBound(1) + 1; j++)
                {
                    result[i, j] = other[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Gets new matrix of sum 
        /// </summary>
        /// <param name="other">Second term</param>
        /// <returns>The matrix</returns>
        public Matrix<T> MatrixSum(Matrix<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (this.RowSize != other.RowSize || this.ColumnSize != other.ColumnSize)
            {
                throw new ArgumentException();
            }

            T[,] result = new T[this.RowSize, this.ColumnSize];

            for (int i = 0; i < this.RowSize; i++)
            {
                for (int j = 0; j < this.ColumnSize; j++)
                {
                    result[i, j] = Add(this.matrix[i, j], other[i, j]);
                }
            }

            return new Matrix<T>(result);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.RowSize; i++)
            {
                for (int j = 0; j < this.ColumnSize; j++)
                {
                    if (this.matrix[i, j] == null)
                    {
                        builder.Append("null ");
                    }
                    else
                    {
                        builder.Append(this.matrix[i, j].ToString() + " ");
                    }
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Starts event
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        protected void OnChangeValue(object sender, MatrixEventArgs<T> e)
        {
            this.Handler?.Invoke(sender, e);
        }

        /// <summary>
        /// Gets sum of universal variables
        /// </summary>
        /// <typeparam name="U">Universal type</typeparam>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <returns>The sum</returns>
        private static U Add<U>(U a, U b)
        {
            if (typeof(string) == typeof(U))
            {
                throw new ArithmeticException();
            }

            ParameterExpression paramA = Expression.Parameter(typeof(U), "a"), paramB = Expression.Parameter(typeof(U), "b");
            BinaryExpression body = Expression.Add(paramA, paramB);
            Func<U, U, U> add = Expression.Lambda<Func<U, U, U>>(body, paramA, paramB).Compile();
            return add(a, b);
        }
    }
}
