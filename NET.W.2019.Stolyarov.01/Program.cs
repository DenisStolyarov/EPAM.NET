using System;

namespace Exercise
{
    class Program
    {
        #region QuickSort
        /// <summary>
        /// Check if parametrs are correct
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="start">Start index position</param>
        /// <param name="end">Last index position</param>
        /// <returns>True or False</returns>
        static bool QuickSort(int[] array, int start, int end)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }
            if (start < 0 || start > end || end >= array.Length)
            {
                return false;
            }
            else
            {
                QSort(array, start, end);
            }
            return true;
        }
        /// <summary>
        /// Sort input array
        /// </summary>
        static void QSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int wall = Division(array, start, end);
            QSort(array, start, wall - 1);
            QSort(array, wall + 1, end);
        }
        /// <summary>
        /// Find a pivot index
        /// </summary>
        /// <returns>Index of pivot point</returns>
        static int Division(int[] array, int start, int end)
        {
            int ptr = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[ptr];
                    array[ptr] = array[i];
                    array[i] = temp;
                    ptr++;
                }
            }
            return ptr - 1;
        }
        #endregion

        #region MergeSort
        /// <summary>
        /// Check if parametrs are correct
        /// </summary>
        /// <param name="array">Unsorted array</param>
        /// <param name="start">Start index position</param>
        /// <param name="end">Last index position</param>
        /// <returns>True or False</returns>
        static bool MergeSort(int[] array, int start, int end)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }
            if (start < 0 || start > end || end >= array.Length)
            {
                return false;
            }
            else
            {
                MSort(array, start, end);
            }
            return true;
        }
        /// <summary>
        /// Sort input array
        /// </summary>
        static void MSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int middleIndex = (start + end) / 2;
                MSort(array, start, middleIndex);
                MSort(array, middleIndex + 1, end);
                Merge(array, start, middleIndex, end);
            }
        }
        /// <summary>
        /// Separate input array on two parts and sort them
        /// </summary>
        /// <param name="middleIndex">Border between array parts</param>
        static void Merge(int[] array, int start, int middleIndex, int end)
        {
            int left = start;
            int right = middleIndex + 1;

            while ((left <= middleIndex) && (right <= end))
            {
                if (array[left] > array[right])
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                }
                else
                {
                    left++;
                }
            }
        }
        #endregion

        #region View
        static void Show(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        #endregion

        static void Main(string[] args)
        {
            int[] Test_1 = new int[] { 0, 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            int[] Test_2 = new int[] { 0, 9, 1, 8, 2, 7, 3, 6, 4, 5 };

            try
            {
                if (QuickSort(Test_1,0,Test_1.Length - 1))
                {
                    Show(Test_1);
                }
                if (MergeSort(Test_1, 0, Test_1.Length - 1))
                {
                    Show(Test_1);
                }
                QuickSort(null, 0, 0);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
