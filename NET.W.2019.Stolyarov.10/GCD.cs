// <copyright file="Exercise.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace ExerciseLib
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class with completed exercises
    /// </summary>
    public static class Exercise
    {
        #region Gcd

        /// <summary>
        /// Executable Algorithm
        /// </summary>
        public static GcdAlgorithm Algorithm = new GcdAlgorithm(EuclidAlgorithm);

        /// <summary>
        /// Base template for gcd Algorithm
        /// </summary>
        public delegate int GcdAlgorithm(int a, int b);

        /// <summary>
        /// Get greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int Gcd(params int[] array)
        {
            if (Algorithm == null)
            {
                throw new NullReferenceException();
            }

            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = Algorithm(Math.Abs(gcd), Math.Abs(array[i]));
            }

            return gcd;
        }

        /// <summary>
        /// Get lead time and greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="time">Out time</param>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int Gcd(out string time, params int[] array)
        {
            if (Algorithm == null)
            {
                throw new NullReferenceException();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = Algorithm(Math.Abs(gcd), Math.Abs(array[i]));
            }

            stopwatch.Stop();
            time = stopwatch.Elapsed.ToString();
            return gcd;
        }

        #endregion

        #region Algorithms
        /// <summary>
        /// Get greatest common divisor between two numbers using binary operations
        /// </summary>
        /// <param name="a">Integer number 1</param>
        /// <param name="b">Integer number 2</param>
        /// <returns>Greatest common divisor</returns>
        public static int BinaryAlgorithm(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return BinaryAlgorithm(a >> 1, b);
                }
                else
                {
                    return BinaryAlgorithm(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return BinaryAlgorithm(a, b >> 1);
            }

            if (a > b)
            {
                return BinaryAlgorithm((a - b) >> 1, b);
            }

            return BinaryAlgorithm((b - a) >> 1, a);
        }

        /// <summary>
        /// Get greatest common divisor between two numbers using Euclid's Algorithm
        /// </summary>
        /// <param name="a">Integer number 1</param>
        /// <param name="b">Integer number 2</param>
        /// <returns>Greatest common divisor</returns>
        public static int EuclidAlgorithm(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        #endregion
    }
}
