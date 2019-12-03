// <copyright file="BookListStorage.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>using System;
namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Agent for working with streams 
    /// </summary>
    public static class BookListStorage
    {
        /// <summary>
        /// Write all books
        /// </summary>
        /// <param name="books">Book container</param>
        /// <param name="path">File path</param>
        public static void Write(List<Book> books, string path)
        {
            if (books == null || path == null)
            {
                throw new NullReferenceException();
            }

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Name);
                        writer.Write(book.Publisher);
                        writer.Write(book.Year);
                        writer.Write(book.Pages);
                        writer.Write(book.Price);
                    }
                }
            }
        }

        /// <summary>
        /// Gets books
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Book collection</returns>
        public static List<Book> Read(string path)
        {
            if (path == null)
            {
                throw new NullReferenceException();
            }

            List<Book> books = new List<Book>();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string ISBN = reader.ReadString();

                        string author = reader.ReadString();

                        string name = reader.ReadString();

                        string publisher = reader.ReadString();

                        int year = reader.ReadInt32();

                        short pages = reader.ReadInt16();

                        decimal price = reader.ReadDecimal();

                        books.Add(new Book(ISBN, author, name, publisher, year, pages, price));
                    }
                }
            }

            return books;
        }
    }
}
