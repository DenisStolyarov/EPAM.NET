using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class BookTests
    {
        readonly Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, (decimal)59.99);

        [TestCase(BookFormater.BookStyle.Short, ExpectedResult = "Jeffrey Richter, CLR via C#")]
        [TestCase(BookFormater.BookStyle.Main, ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
        [TestCase(BookFormater.BookStyle.Long, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826.")]
        [TestCase(BookFormater.BookStyle.Full, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826., 59,99$.")]
        public string BookFormatTests(BookFormater.BookStyle style)
        {
            return book.BookFormat(style);
        }
    }
}