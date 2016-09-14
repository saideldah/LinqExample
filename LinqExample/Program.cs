using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var bookList = GetBookList();

            //LINQ Query Operator
            var bookList1 = from b in bookList
                where b.Price < 100 
                orderby b.Price 
                select b
            ;
            foreach (Book book in bookList1)
            {
                Console.WriteLine(book.Title + " : " + book.Price);
            }
            Console.WriteLine("--------------------------------");

            //LinqExample Extension Methods
            var bookTitleList = bookList
                .Where(b => b.Price < 100)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            foreach (var bookTitle in bookTitleList)
            {
                Console.WriteLine(bookTitle);
            }
            Console.WriteLine("--------------------------------");

            var myBook = bookList.Single(b => b.Title == "B");
            Console.WriteLine(myBook.Title);
            Console.WriteLine("--------------------------------");

            myBook = bookList.FirstOrDefault(b => b.Title == "A");
            Console.WriteLine(myBook.Title + ": " + myBook.Price);
            Console.WriteLine("--------------------------------");

            myBook = bookList.LastOrDefault(b => b.Title == "A");
            Console.WriteLine(myBook.Title + ": " + myBook.Price);
            Console.WriteLine("--------------------------------");

            //skip the first two object and take the next three after the two
            var bookList2 = bookList.Skip(2).Take(3);
            foreach (Book book in bookList2)
            {
                Console.WriteLine(book.Title);
            }

            //aggregate function
            //Count 
            //Sum Max Min
            Console.WriteLine("--------------------------------");

            var myList = bookList.Select(b => b.Title + " " +b.Price);
            foreach (var var in myList)
            {
                Console.WriteLine(var);
            }
        }

        static IEnumerable<Book> GetBookList()
        {
            return new List<Book>()
            {
                new Book() {Title = "gege", Price = 50},
                new Book() {Title = "A", Price = 90},
                new Book() {Title = "A", Price = 100},
                new Book() {Title = "mama", Price = 500},
                new Book() {Title = "Ahmad", Price = 200},
                new Book() {Title = "B", Price = 30},
                new Book() {Title = "SAeed", Price = 20},
            };
        }
    }
}
