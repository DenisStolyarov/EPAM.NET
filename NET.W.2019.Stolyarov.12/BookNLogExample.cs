using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static BookListService ListService = new BookListService();

        static void Show()
        {
            logger.Trace("Show method start");
            foreach (var book in ListService.GetBooks())
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            logger.Trace("Show method end");
        }

        static void Main(string[] args)
        {
            try
            { 
                logger.Info("Test work of BookService");
                logger.Info("Create book instance");

                Book book_1 = new Book("9785040994434", "Стивен Хокинг", "Краткие ответы на большие вопросы", "Эксмо", 2019, 256, 7);
                Book book_2 = new Book("9785170801152", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 4);
                Book book_3 = new Book("9789851534315", "Джордж Клейсон", "Самый богатый человек в Вавилоне", "Попурри", 2018, 176, 6);
                Book book_4 = new Book("0000000000000", "", "", "", 0, 0, 0);
                Book book_5 = new Book("9785171023409", "Стивен Хокинг", "Теория всего", "АСТ", 2017, 160, 6);

                logger.Info("Add book instance to service");
                ListService.AddBook(book_1);
                ListService.AddBook(book_2);
                ListService.AddBook(book_3);
                ListService.AddBook(book_4);
                ListService.AddBook(book_5);

                logger.Info("Add book instance to service");
                ListService.RemoveBook(book_4);

                logger.Info("Find book instances by Author");
                foreach (var item in ListService.FindBookByTag("Author", "Стивен Хокинг"))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                logger.Info("Find book instances by Publisher");
                foreach (var item in ListService.FindBookByTag("Publisher", "аст"))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                logger.Info("Find book instances by Price");
                foreach (var item in ListService.FindBookByTag("Price", "6"))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                logger.Info("Sort book instances by Price");
                ListService.SortBookByTag("Price");
                Show();

                logger.Info("Sort book instances by Year");
                ListService.SortBookByTag("Year");
                Show();

                logger.Info("Save book instances in storage");
                string path = @"D:\Books.txt";
                ListService.Save(path);

                logger.Info("Clear book instances");
                ListService.Clear();

                logger.Info("Load book instances in service");
                ListService.Load(path);
                Show();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }
    }
}