﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

// Using the Bookstore classes:
namespace BookTestClient
{
    using BookStoreDelegate;

    // Class to total and average prices of books:
    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(BookStoreDelegate.Program.Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    // Class to test the book database:
    class Test
    {
        // Print the title of the book.
        static void PrintTitle(BookStoreDelegate.Program.Book b)
        {
            Console.WriteLine("   {0}", b.Title);
        }

        // Execution starts here.
        static void Main()
        {
            BookStoreDelegate.Program.BookDB bookDB = new BookStoreDelegate.Program.BookDB();

            // Initialize the database with some books:
            AddBooks(bookDB);

            // Print all the titles of paperbacks:
            Console.WriteLine("Paperback Book Titles:");
            // Create a new delegate object associated with the static 
            // method Test.PrintTitle:
            bookDB.ProcessPaperbackBooks(new BookStoreDelegate.Program.ProcessBookDelegate(PrintTitle));

            // Get the average price of a paperback by using
            // a PriceTotaller object:
            PriceTotaller totaller = new PriceTotaller();
            // Create a new delegate object associated with the nonstatic 
            // method AddBookToTotal on the object totaller:
            bookDB.ProcessPaperbackBooks(new BookStoreDelegate.Program.ProcessBookDelegate(totaller.AddBookToTotal));
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
               totaller.AveragePrice());
            Console.ReadKey();
        }

        // Initialize the book database with some test books:
        static void AddBooks(BookStoreDelegate.Program.BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language",
               "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0",
               "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia",
               "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless",
               "Scott Adams", 12.00m, true);
        }
    }
}
