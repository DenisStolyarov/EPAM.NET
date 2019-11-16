using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace ExerciseLib
{
    public static class Exercise
    {
        /// <summary>
        /// Unite some bits between numbers
        /// </summary>
        /// <param name="numberSource">Source</param>
        /// <param name="numberIn">Bit mask</param>
        /// <param name="i">Start bit</param>
        /// <param name="j">Last bit</param>
        /// <returns>Union number</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j || i < 0)
            {
                return -1;
            }
            else
            {
                return numberSource | ((numberIn & ((1 << (j - i + 1)) - 1)) << i);
            }
        }

        /// <summary>
        /// Find bigger number that contains same digits
        /// </summary>
        /// <param name="numberIn">Source</param>
        /// <returns>Filter Number or -1</returns>
        public static int FindNextBiggerNumber(int numberIn)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            char[] array = Convert.ToString(numberIn).ToCharArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    //Swap
                    char temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                    //Residual array
                    char[] c = (array.Skip(i).OrderBy(a => a)).ToArray();
                    //Union
                    for (int j = i, k = 0; j < array.Length; j++, k++)
                    {
                        array[j] = c[k];
                    }
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.Elapsed);
                    return Convert.ToInt32(new string(array));
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            return -1;
        }

        /// <summary>
        /// Take numbers from array that contains source digit
        /// </summary>
        /// <param name="digit">Number from 0 to 9</param>
        /// <param name="array">Source</param>
        /// <returns>Filter array</returns>
        public static int[] FilterDigit(int digit, int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }
            List<int> list = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (Convert.ToString(array[i]).IndexOf(digit.ToString()) != -1)
                {
                    list.Add(array[i]);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Get n-root from number
        /// </summary>
        /// <param name="number">Source</param>
        /// <param name="n">Degree</param>
        /// <param name="epsilon">Border</param>
        /// <returns>Number</returns>
        public static double FindNthRoot(double number, int n, double epsilon)
        {
            if (n < 2 || epsilon < 0 || epsilon > 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n % 2 == 0 && number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 1)
            {
                return number;
            }
            int round = 0;
            for (double i = epsilon; i < 1; i *= 10)
            {
                round++;
            }

            double current = 0.1, root = 1.0 / n * ((n - 1) * current + number / Math.Pow(current, n - 1));
            while (Math.Abs(root - current) >= epsilon)
            {
                current = root;
                root = 1.0 / n * ((n - 1) * current + number / Math.Pow(current, n - 1));
            }
            return Math.Round(root, round);
        }
    }
}
