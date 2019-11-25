// <copyright file="Exercise.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace ExerciseLib
{
    using System;

    /// <summary>
    /// Class with basic operations of polynomial
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Single-dimensional or zero-based array
        /// </summary>
        private readonly double[] polynomial;

        /// <summary>
        /// Number of decimal places
        /// </summary>
        private int roundIndex = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class
        /// </summary>
        public Polynomial()
        {
            throw new ArgumentException("It's need to be not empty!");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class
        /// </summary>
        /// <param name="polynomial">Array with coefficients</param>
        public Polynomial(params double[] polynomial)
        {
            if (polynomial == null)
            {
                throw new NullReferenceException();
            }

            if (polynomial.Length == 0)
            {
                throw new ArgumentException("It's need to be not empty!");
            }
            else
            {
                for (int i = 0; i < polynomial.Length; i++)
                {
                    polynomial[i] = Math.Round(polynomial[i], this.roundIndex);
                    if (polynomial[i] != 0)
                    {
                        this.Degree = i;
                    }
                }
            }

            this.polynomial = polynomial;
        }

        /// <summary>
        /// Gets maximum non-zero degree
        /// </summary>
        public int Degree { get; private set; }

        /// <summary>
        /// Get coefficient of polynomial
        /// </summary>
        /// <param name="index">Element position</param>
        /// <returns>Double value</returns>
        public double this[int index]
        {
            get
            {
                if (index >= this.polynomial.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.polynomial[index];
            }
        }

        /// <summary>
        /// Get sum of polynomials
        /// </summary>
        /// <param name="firstOperand">First term</param>
        /// <param name="secondOperand">Second term</param>
        /// <returns> Polynomial value </returns>
        public static Polynomial operator +(Polynomial firstOperand, Polynomial secondOperand)
        {
            double[] result;
            if (firstOperand.Degree > secondOperand.Degree)
            {
                result = new double[firstOperand.Degree + 1];
                for (int i = 0; i < secondOperand.Degree + 1; i++)
                {
                    result[i] = firstOperand[i] + secondOperand[i];
                }

                for (int i = secondOperand.Degree + 1; i < firstOperand.Degree + 1; i++)
                {
                    result[i] = firstOperand[i];
                }

                return new Polynomial(result);
            }
            else
            {
                result = new double[secondOperand.Degree + 1];
                for (int i = 0; i < firstOperand.Degree + 1; i++)
                {
                    result[i] = firstOperand[i] + secondOperand[i];
                }

                for (int i = firstOperand.Degree + 1; i < secondOperand.Degree + 1; i++)
                {
                    result[i] = secondOperand[i];
                }

                return new Polynomial(result);
            }
        }

        /// <summary>
        /// Get subtraction of polynomials
        /// </summary>
        /// <param name="firstOperand">Minuend value</param>
        /// <param name="secondOperand">Subtrahend value</param>
        /// <returns> Polynomial value </returns>
        public static Polynomial operator -(Polynomial firstOperand, Polynomial secondOperand)
        {
            double[] result;
            if (firstOperand.Degree > secondOperand.Degree)
            {
                result = new double[firstOperand.Degree + 1];
                for (int i = 0; i < secondOperand.Degree + 1; i++)
                {
                    result[i] = firstOperand[i] - secondOperand[i];
                }

                for (int i = secondOperand.Degree + 1; i < firstOperand.Degree + 1; i++)
                {
                    result[i] = -1 * firstOperand[i];
                }

                return new Polynomial(result);
            }
            else
            {
                result = new double[secondOperand.Degree + 1];
                for (int i = 0; i < firstOperand.Degree + 1; i++)
                {
                    result[i] = firstOperand[i] - secondOperand[i];
                }

                for (int i = firstOperand.Degree + 1; i < secondOperand.Degree + 1; i++)
                {
                    result[i] = -1 * secondOperand[i];
                }

                return new Polynomial(result);
            }
        }

        /// <summary>
        /// Get multiplication of polynomials
        /// </summary>
        /// <param name="firstOperand">First multiplier</param>
        /// <param name="secondOperand">Second multiplier</param>
        /// <returns> Polynomial value </returns>
        public static Polynomial operator *(Polynomial firstOperand, Polynomial secondOperand)
        {
            double[] result;
            if (firstOperand.Degree > 1 && secondOperand.Degree > 1)
            {
                result = new double[(firstOperand.Degree * secondOperand.Degree) + 1];
            }
            else
            {
                result = new double[(firstOperand.Degree * secondOperand.Degree) + 2];
            }

            for (int i = 0; i < firstOperand.Degree + 1; i++)
            {
                for (int j = 0; j < secondOperand.Degree + 1; j++)
                {
                    result[i + j] += Math.Round(firstOperand[i] * secondOperand[j], firstOperand.roundIndex);
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Compare the conformity of sizes and elements
        /// </summary>
        /// <param name="firstOperand">First Polynomial</param>
        /// <param name="secondOperand">Second Polynomial</param>
        /// <returns>Bool value</returns>
        public static bool operator ==(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (firstOperand.Degree == secondOperand.Degree)
            {
                for (int i = 0; i < firstOperand.Degree; i++)
                {
                    if (firstOperand[i] != secondOperand[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check the difference of sizes and elements
        /// </summary>
        /// <param name="firstOperand">First Polynomial</param>
        /// <param name="secondOperand">Second Polynomial</param>
        /// <returns> Bool value </returns>
        public static bool operator !=(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (firstOperand.Degree == secondOperand.Degree)
            {
                for (int i = 0; i < firstOperand.Degree; i++)
                {
                    if (firstOperand[i] != secondOperand[i])
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Compare reference
        /// </summary>
        /// <param name="obj">Link of the object</param>
        /// <returns> Bool value </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Polynomial personObj))
            {
                return false;
            }
            else
            {
                return base.Equals(personObj);
            }
        }

        /// <summary>
        /// Create Hash-value
        /// </summary>
        /// <returns> Hash value </returns>
        public override int GetHashCode()
        {
            return this.polynomial.GetHashCode() + this.Degree.GetHashCode();
        }

        /// <summary>
        /// Get the equation
        /// </summary>
        /// <returns>String equation</returns>
        public override string ToString()
        {
            string equation = string.Empty;
            if (this.polynomial[0] != 0 || this.Degree == 0)
            {
                equation += this.polynomial[0].ToString();
            }

            for (int i = 1; i < this.Degree + 1; i++)
            {
                if (this.polynomial[i] > 0 && equation.Length > 0)
                {
                    equation += "+";
                }

                if (this.polynomial[i] != 0)
                {
                    equation += this.polynomial[i].ToString() + "X^" + i.ToString();
                }
            }

            return equation;
        }
    }

    /// <summary>
    /// Class with jagged array sort methods
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// Get maximum element of array
        /// </summary>
        /// <param name="array">Input value</param>
        /// <returns> Maximum value </returns>
        public static int Max(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Null element");
            }

            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Get minimal element of array
        /// </summary>
        /// <param name="array">Input value</param>
        /// <returns> Minimal value </returns>
        public static int Min(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Null element");
            }

            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Get sum of all elements
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns> Sum value </returns>
        public static int Sum(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new NullReferenceException("Null element");
            }

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        /// <summary>
        /// Swap two arrays
        /// </summary>
        /// <param name="arr1">First array</param>
        /// <param name="arr2">Second array</param>
        public static void Swap(ref int[] arr1, ref int[] arr2)
        {
            // Temporary variable
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        /// <summary>
        /// Sort jagged array by line by ascend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortAscending(int[][] jaggedArray, Func<int[], int> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare(jaggedArray[j]) > compare(jaggedArray[j + 1]))
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array by line by descend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortDescending(int[][] jaggedArray, Func<int[], int> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare(jaggedArray[j]) < compare(jaggedArray[j + 1]))
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }
    }
}
