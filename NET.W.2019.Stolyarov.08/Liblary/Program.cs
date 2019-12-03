using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Program
    {
        public static BookListService ListService = new BookListService();

        static void Show()
        {
            foreach (var book in ListService.GetBooks())
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try
            {
                Book book_1 = new Book("9785040994434", "Стивен Хокинг", "Краткие ответы на большие вопросы", "Эксмо", 2019, 256, 7);
                Book book_2 = new Book("9785170801152", "Джордж Оруэлл", "1984", "АСТ", 2015, 320, 4);
                Book book_3 = new Book("9789851534315", "Джордж Клейсон", "Самый богатый человек в Вавилоне", "Попурри", 2018, 176, 6);
                Book book_4 = new Book("0000000000000", "", "", "", 0, 0, 0);
                Book book_5 = new Book("9785171023409", "Стивен Хокинг", "Теория всего", "АСТ", 2017, 160, 6);

                ListService.AddBook(book_1);
                ListService.AddBook(book_2);
                ListService.AddBook(book_3);
                ListService.AddBook(book_4);
                ListService.AddBook(book_5);

                ListService.RemoveBook(book_4);
                
                foreach (var item in ListService.FindBookByTag("Author", "Стивен Хокинг"))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                foreach (var item in ListService.FindBookByTag("Publisher", "аст"))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                foreach (var item in ListService.FindBookByTag("Price", "6"))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                ListService.SortBookByTag("Price");
                Show();

                ListService.SortBookByTag("Year");
                Show();

                string path = @"D:\Books.txt";
                ListService.Save(path);

                ListService.Clear();

                ListService.Load(path);
                Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
