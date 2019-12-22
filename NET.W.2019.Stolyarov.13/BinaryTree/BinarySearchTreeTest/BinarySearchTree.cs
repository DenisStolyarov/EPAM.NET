using NUnit.Framework;
using Result;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [Test]
        public void IntDefaultComparison()
        {
            BinarySearchTree<int> intBinaryTree = new BinarySearchTree<int>();
            intBinaryTree.Insert(5);
            intBinaryTree.Insert(4);
            intBinaryTree.Insert(-6);
            intBinaryTree.Insert(3);
            intBinaryTree.Insert(7);

            Assert.AreEqual(new int[] { 5, 4, -6, 3, 7 }, intBinaryTree.PreOrder());
            Assert.AreEqual(new int[] { -6, 3, 4, 5, 7 }, intBinaryTree.InOrder());
            Assert.AreEqual(new int[] { 3, -6, 4, 7, 5 }, intBinaryTree.PostOrder());
        }

        [Test]
        public void IntComparatorComparison()
        {
            BinarySearchTree<int> intBinaryTree = new BinarySearchTree<int>(new IntComparer());
            intBinaryTree.Insert(5);
            intBinaryTree.Insert(4);
            intBinaryTree.Insert(-6);
            intBinaryTree.Insert(3);
            intBinaryTree.Insert(7);

            Assert.AreEqual(new int[] { 5, 4, 3, -6, 7 }, intBinaryTree.PreOrder());
            Assert.AreEqual(new int[] {3, 4, 5, -6, 7 }, intBinaryTree.InOrder());
            Assert.AreEqual(new int[] { 3, 4, 7, -6, 5 }, intBinaryTree.PostOrder());
        }

        [Test]
        public void StringDefaultComparison()
        {
            BinarySearchTree<string> intBinaryTree = new BinarySearchTree<string>();
            intBinaryTree.Insert("c");
            intBinaryTree.Insert("aa");
            intBinaryTree.Insert("bbb");
            intBinaryTree.Insert("dd");
            intBinaryTree.Insert("e");

            Assert.AreEqual(new string[] { "c", "aa", "bbb", "dd", "e" }, intBinaryTree.PreOrder());
            Assert.AreEqual(new string[] { "aa", "bbb", "c", "dd", "e" }, intBinaryTree.InOrder());
            Assert.AreEqual(new string[] { "bbb", "aa", "e", "dd", "c", }, intBinaryTree.PostOrder());
        }

        [Test]
        public void StringComparatorComparison()
        {
            BinarySearchTree<string> intBinaryTree = new BinarySearchTree<string>(new StringLenghtComparer());
            intBinaryTree.Insert("c");
            intBinaryTree.Insert("aa");
            intBinaryTree.Insert("bbb");
            intBinaryTree.Insert("dd");
            intBinaryTree.Insert("e");

            Assert.AreEqual(new string[] { "c", "aa", "e", "bbb", "dd" }, intBinaryTree.PreOrder());
            Assert.AreEqual(new string[] { "c", "e", "aa", "dd", "bbb" }, intBinaryTree.InOrder());
            Assert.AreEqual(new string[] { "e", "dd", "bbb", "aa", "c" }, intBinaryTree.PostOrder());
        }

        [Test]
        public void BookgDefaultComparison()
        {
            BinarySearchTree<Book> intBinaryTree = new BinarySearchTree<Book>();

            Book book_1 = new Book("9785040994434", "Стивен Хокинг", "Краткие ответы на большие вопросы", "Эксмо", 2019, 256, 7);
            Book book_2 = new Book("9785170801152", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 4);
            Book book_3 = new Book("9789851534315", "Джордж Клейсон", "Самый богатый человек в Вавилоне", "Попурри", 2018, 176, 6);
            Book book_4 = new Book("0000000000000", "", "", "", 0, 0, 0);
            Book book_5 = new Book("9785171023409", "Стивен Хокинг", "Теория всего", "АСТ", 2017, 160, 6);

            intBinaryTree.Insert(book_1);
            intBinaryTree.Insert(book_2);
            intBinaryTree.Insert(book_3);
            intBinaryTree.Insert(book_4);
            intBinaryTree.Insert(book_5);

            Assert.AreEqual(new Book[] { book_1, book_4, book_2, book_3, book_5 }, intBinaryTree.PreOrder());
            Assert.AreEqual(new Book[] { book_4, book_1, book_2, book_5, book_3 }, intBinaryTree.InOrder());
            Assert.AreEqual(new Book[] { book_4, book_5, book_3, book_2, book_1 }, intBinaryTree.PostOrder());
        }

        [Test]
        public void BookComparatorComparison()
        {
            BinarySearchTree<Book> intBinaryTree = new BinarySearchTree<Book>(new BookComparer());

            Book book_1 = new Book("9785040994434", "Стивен Хокинг", "Краткие ответы на большие вопросы", "Эксмо", 2019, 256, 7);
            Book book_2 = new Book("9785170801152", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 4);
            Book book_3 = new Book("9789851534315", "Джордж Клейсон", "Самый богатый человек в Вавилоне", "Попурри", 2018, 176, 6);
            Book book_4 = new Book("0000000000000", "", "", "", 0, 0, 0);
            Book book_5 = new Book("9785171023409", "Стивен Хокинг", "Теория всего", "АСТ", 2017, 160, 6);

            intBinaryTree.Insert(book_1);
            intBinaryTree.Insert(book_2);
            intBinaryTree.Insert(book_3);
            intBinaryTree.Insert(book_4);
            intBinaryTree.Insert(book_5);

            Assert.AreEqual(new Book[] { book_1, book_2, book_4, book_3, book_5 }, intBinaryTree.PreOrder());
            Assert.AreEqual(new Book[] { book_4, book_2, book_3, book_5, book_1 }, intBinaryTree.InOrder());
            Assert.AreEqual(new Book[] { book_4, book_5, book_3, book_2, book_1 }, intBinaryTree.PostOrder());
        }

        [Test]
        public void PointComparatorComparison()
        {
            BinarySearchTree<Point> intBinaryTree = new BinarySearchTree<Point>(new PointComparer());

            Point point_1 = new Point(0, 0, 0);
            Point point_2 = new Point(0, 1, 0);
            Point point_3 = new Point(1, 1, 1);
            Point point_4 = new Point(1, 0, 0);
            Point point_5 = new Point(2, 2, 2);

            intBinaryTree.Insert(point_1);
            intBinaryTree.Insert(point_2);
            intBinaryTree.Insert(point_3);
            intBinaryTree.Insert(point_4);
            intBinaryTree.Insert(point_5);

            Assert.AreEqual(new Point[] { point_1, point_2, point_3, point_4, point_5 }, intBinaryTree.PreOrder());
            Assert.AreEqual(new Point[] { point_1, point_2, point_3, point_4, point_5 }, intBinaryTree.InOrder());
            Assert.AreEqual(new Point[] { point_5, point_4, point_3, point_2, point_1 }, intBinaryTree.PostOrder());
        }
    }
}