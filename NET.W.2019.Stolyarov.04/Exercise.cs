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
        #region BinaryGcd

        /// <summary>
        /// Get greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int BinaryGcd(params int[] array)
        {
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = Bgce(Math.Abs(gcd), Math.Abs(array[i]));
            }

            return gcd;
        }

        /// <summary>
        /// Get lead time and greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="time">Out time</param>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int BinaryGcd(out string time, params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = Bgce(Math.Abs(gcd), Math.Abs(array[i]));
            }

            stopwatch.Stop();
            time = stopwatch.Elapsed.ToString();
            return gcd;
        }

        #endregion

        #region EuclidGcd

        /// <summary>
        /// Get greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int EuclidGcd(params int[] array)
        {
            int gcd = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                gcd = Egcd(Math.Abs(gcd), Math.Abs(array[i]));
            }

            return gcd;
        }

        /// <summary>
        /// Get lead time and greatest common divisor from a lot of parameters
        /// </summary>
        /// <param name="time">Out time</param>
        /// <param name="array">Variable number of parameters</param>
        /// <returns>Greatest common divisor</returns>
        public static int EuclidGcd(out string time, params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = Egcd(Math.Abs(gcd), Math.Abs(array[i]));
            }

            stopwatch.Stop();
            time = stopwatch.Elapsed.ToString();
            return gcd;
        }
        
        #endregion

        #region BinaryFormat

        /// <summary>
        /// Get bit representation of a number
        /// </summary>
        /// <param name="number">Real number</param>
        /// <returns>Bit representation string</returns>
        public static string BinaryFormat(this double number)
        {
            long temp;
            string result = string.Empty;
            unsafe
            {
                double* bptr;
                bptr = &number;
                long* lptr = (long*)bptr;
                temp = *lptr;

                for (int i = 63; i >= 0; i--)
                {
                    result += (((temp >> i) & 1) == 0) ? "0" : "1";
                }
            }

            return result;
        }

        #endregion

        #region PrivateMetods
        /// <summary>
        /// Get greatest common divisor between two numbers using binary operations
        /// </summary>
        /// <param name="a">Integer number 1</param>
        /// <param name="b">Integer number 2</param>
        /// <returns>Greatest common divisor</returns>
        private static int Bgce(int a, int b)
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
                    return Bgce(a >> 1, b);
                }
                else
                {
                    return Bgce(a >> 1, b >> 1) << 1;
                }  
            }

            if ((~b & 1) != 0)
            {
                return Bgce(a, b >> 1);
            }
               
            if (a > b)
            {
                return Bgce((a - b) >> 1, b);
            }
                
            return Bgce((b - a) >> 1, a);
        }

        /// <summary>
        /// Get greatest common divisor between two numbers using Euclid's algorithm
        /// </summary>
        /// <param name="a">Integer number 1</param>
        /// <param name="b">Integer number 2</param>
        /// <returns>Greatest common divisor</returns>
        private static int Egcd(int a, int b)
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
