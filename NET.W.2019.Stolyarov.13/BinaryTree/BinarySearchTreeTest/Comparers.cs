namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class IntComparer : IComparer<int>
    {
        /// <inheritdoc/>
        public int Compare(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);

            if (x > y)
            {
                return 1;
            }

            if (x < y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class StringLenghtComparer : IComparer<string>
    {
        /// <inheritdoc/>
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }

            if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class PointComparer : IComparer<Point>
    {
        /// <inheritdoc/>
        public int Compare(Point x, Point y)
        {
            if (x.x > y.x && x.y > y.y && x.z > y.z)
            {
                return 1;
            }

            if (x.x < y.x && x.y < y.y && x.z < y.z)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class BookComparer : IComparer<Book>
    {
        /// <inheritdoc/>
        public int Compare(Book x, Book y)
        {
            if (x.Price > y.Price)
            {
                return 1;
            }

            if (x.Price < y.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
