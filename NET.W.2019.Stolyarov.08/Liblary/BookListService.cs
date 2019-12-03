// <copyright file="BookListService.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Service for work with book library
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Book container
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException();
            }

            if (this.IsExist(book))
            {
                throw new ArgumentException();
            }
            else
            {
                this.books.Add(book);
            }
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException();
            }

            if (!this.IsExist(book))
            {
                throw new ArgumentException();
            }
            else
            {
                this.books.Remove(book);
            }
        }

        /// <summary>
        /// Sort all books by certain criterion
        /// </summary>
        /// <param name="criterion">Book criterion</param>
        public void SortBookByTag(string criterion)
        {
            if (criterion == null)
            {
                throw new NullReferenceException();
            }

            switch (criterion.ToLower())
            {
                case "isbn":
                    this.books = this.books.OrderBy(i => i.ISBN).ToList();
                    break;
                case "author":
                    this.books = this.books.OrderBy(i => i.Author).ToList();
                    break;
                case "name":
                    this.books = this.books.OrderBy(i => i.Name).ToList();
                    break;
                case "publisher":
                    this.books = this.books.OrderBy(i => i.Publisher).ToList();
                    break;
                case "year":
                    this.books = this.books.OrderBy(i => i.Year).ToList();
                    break;
                case "pages":
                    this.books = this.books.OrderBy(i => i.Pages).ToList();
                    break;
                case "price":
                    this.books = this.books.OrderBy(i => i.Price).ToList();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Find all books by certain criterion
        /// </summary>
        /// <param name="criterion"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Book> FindBookByTag(string criterion, string param)
        {
            if (criterion == null)
            {
                throw new NullReferenceException();
            }

            List<Book> books;

            switch (criterion.ToLower())
            {
                case "isbn":
                    books = this.books.FindAll(i => i.ISBN.ToLower() == param.ToLower());
                    break;
                case "author":
                    books = this.books.FindAll(i => i.Author.ToLower() == param.ToLower());
                    break;
                case "name":
                    books = this.books.FindAll(i => i.Name.ToLower() == param.ToLower());
                    break;
                case "publisher":
                    books = this.books.FindAll(i => i.Publisher.ToLower() == param.ToLower());
                    break;
                case "year":
                    int year = int.Parse(param);
                    books = this.books.FindAll(i => i.Year == year);
                    break;
                case "pages":
                    short pages = short.Parse(param);
                    books = this.books.FindAll(i => i.Pages == pages);
                    break;
                case "price":
                    decimal price = decimal.Parse(param);
                    books = this.books.FindAll(i => i.Price == price);
                    break;
                default:
                    throw new ArgumentException();
            }

            return books;
        }

        /// <summary>
        /// Write all records in file
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            if (this.books.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            BookListStorage.Write(this.books, path);
        }

        /// <summary>
        /// Gets records from file
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            if (this.books.Count != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.books = BookListStorage.Read(path);
        }

        /// <summary>
        /// Returns copy of container
        /// </summary>
        /// <returns></returns>
        public Book[] GetBooks()
        {
            return this.books.ToArray();
        }

        /// <summary>
        /// Remove all records
        /// </summary>
        public void Clear()
        {
            this.books = new List<Book>();
        }

        /// <summary>
        /// Check unique id
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private bool IsExist(Book book)
        {
            foreach (IEquatable<Book> item in this.books)
            {
                if (item.Equals(book))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
