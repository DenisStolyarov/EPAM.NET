// <copyright file="BookFormater.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Library
{
	/// <summary>
        /// Presentation type
        /// </summary>
        public enum BookStyle
        {
            /// <summary>
            /// [Author] [Name]
            /// </summary>
            Short,

            /// <summary>
            /// [Author] [Name] [Publisher] [Year]
            /// </summary>
            Main,

            /// <summary>
            /// [Author] [Name] [Publisher] [Year] [Pages]
            /// </summary>
            Long,

            /// <summary>
            /// [Author] [Name] [Publisher] [Year] [Pages] [Price]
            /// </summary>
            Full
        }

    /// <summary>
    /// Extensions for Book class
    /// </summary>
    public static class BookFormater
    {
        /// <summary>
        /// Gets presentation of book information 
        /// </summary>
        /// <param name="book">Book instance</param>
        /// <param name="style">Presentation type</param>
        /// <returns>Book information </returns>
        public static string BookFormat(this Book book, BookStyle style)
        {
            switch (style)
            {
                case BookStyle.Short:
                    return $"{book.Author}, {book.Name}";
                case BookStyle.Main:
                    return $"{book.Author}, {book.Name}, \"{book.Publisher}\", {book.Year}";
                case BookStyle.Long:
                    return $"ISBN 13: {book.ISBN}, {book.Author}, {book.Name}, \"{book.Publisher}\", {book.Year}, P. {book.Pages}.";
                case BookStyle.Full:
                    return $"ISBN 13: {book.ISBN}, {book.Author}, {book.Name}, \"{book.Publisher}\", {book.Year}, P. {book.Pages}., {book.Price}$."; 
                default:
                    return book.ToString();
            }
        }
    }
}
