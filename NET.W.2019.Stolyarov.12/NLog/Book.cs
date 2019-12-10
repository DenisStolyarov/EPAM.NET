// <copyright file="Book.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Library
{
    using System;

    /// <summary>
    /// Book item
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="ISBN">Unique identifier</param>
        /// <param name="author">Author name</param>
        /// <param name="name">Book name</param>
        /// <param name="publisher">Publisher name</param>
        /// <param name="year">The year of publishing</param>
        /// <param name="pages">Page counts</param>
        /// <param name="price">Book price</param>
        public Book(string ISBN, string author, string name, string publisher, int year, short pages, decimal price)
        {
            if (ISBN == null || name == null || author == null || publisher == null)
            {
                throw new NullReferenceException();
            }

            if (ISBN.Length > 17)
            {
                throw new ArgumentException();
            }

            if (year > DateTime.Now.Year)
            {
                throw new ArgumentException();
            }

            if (pages < 0 || price < 0)
            {
                throw new ArgumentException();
            }

            this.ISBN = ISBN;
            this.Author = author;
            this.Name = name;
            this.Publisher = publisher;
            this.Year = year;
            this.Pages = pages;
            this.Price = price;
        }

        private Book() { }

        /// <summary>
        /// Gets unique identifier
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// Gets author name
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Gets book name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets publisher name
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets year of publishing
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Gets page counts
        /// </summary>
        public short Pages { get; private set; }

        /// <summary>
        /// Gets book price
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        int IComparable<Book>.CompareTo(Book other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.ISBN.CompareTo(other.ISBN);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool IEquatable<Book>.Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.ISBN == other.ISBN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Book)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode() + this.Name.GetHashCode() + this.Author.GetHashCode();
        }

        /// <summary>
        /// Return book information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.ISBN}, {this.Author}, {this.Name}, {this.Publisher}, {this.Year}, {this.Pages}, {this.Price}$";
        }
    }
}