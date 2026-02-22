using LibraryManagementSystem;
using LINQ_DATA;
using System.Collections;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var q1 = LibraryData.Books.Where(b => b.IsAvailable);
            
            var q2 = LibraryData.Books.Select(b => b.Title);
            
            var q3 = LibraryData.Books.Where(b => b.Genre == "Programming");
            
            var q4 = LibraryData.Books.OrderBy(b => b.Title);
            
            var q5 = LibraryData.Books.Where(b => b.Price > 30m);
            
            var q6 = LibraryData.Books.Select(b => b.Genre).Distinct();
            
            var q7 = LibraryData.Books.GroupBy(b => b.Genre).Select(b => new { Genre = b.Key, Count = b.Count() });
            
            var q8 = LibraryData.Books.Where(b => b.PublishedYear > 2010);
            
            var q9 = LibraryData.Books.Take(5);
            
            var q10 = LibraryData.Books.Any(b => b.Price > 50m);
            
            var q11 = from book in LibraryData.Books
                      join author in LibraryData.Authors
                      on book.AuthorId equals author.Id
                      select new { book.Title, author.Name, book.Genre };
            
            // select must have an object type after it
            var q12 = LibraryData.Books.GroupBy(b => b.Genre).Select(b => new { Genre = b.Key, Average = b.Average(b => b.Price) });
            
            // the array to make console table work xD (omit if we want the object only)
            var q13 = new Book?[] { LibraryData.Books.MaxBy(b => b.Price) };
            // Max returns the value, MaxBy returns the full object

            var q14 = LibraryData.Books
                .GroupBy(b => b.PublishedYear / 10 * 10);
            //foreach (var x in q14)
            //{
            //    foreach (var y in x)
            //    {
            //        Console.WriteLine($"{x.Key} - {y.Title}");
            //    }
            //}
            
            var q15 = from loans in LibraryData.Loans join
                      members in LibraryData.Members on
                      loans.MemberId equals members.Id
                      where loans.ReturnDate is null
                      select members;

            var q16 = from loans in LibraryData.Loans
                      join books in LibraryData.Books on
                      loans.BookId equals books.Id
                      group books by books.Title into b
                      where b.Count() > 1
                      select new { b.Key, Count = b.Count() };

            var q17 = from loans in LibraryData.Loans
                      join books in LibraryData.Books on
                      loans.BookId equals books.Id
                      where loans.DueDate < DateTime.Now
                      && loans.ReturnDate == null
                      select books;

            var q18 = from authors in LibraryData.Authors
                      join books in LibraryData.Books
                      on authors.Id equals books.AuthorId
                      group authors by new { authors.Id , authors.Name } into a
                      orderby a.Count() descending
                      select new { Author = a.Key.Name, BookCount = a.Count() };

            var q19 = LibraryData.Books.Select(b =>
            {
                if (b.Price > 40) return "Expensive";
                else if (b.Price > 20) return "Medium";
                else return "Cheap";
            }).GroupBy(b => b)
            .Select(b => new {Category = b.Key, Count = b.Count()});

            DateTime now = DateTime.Now;

            var q20 = from loans in LibraryData.Loans
                      join members in LibraryData.Members
                      on loans.MemberId equals members.Id
                      // grouping by integers is faster, but we keep the full name to display
                      group loans by new { members.Id, members.FullName } into m
                      
                      select new { m.Key.FullName,
                          TotalLoans = m.Count(),
                          ActiveLoans = m.Count(m => m.ReturnDate is null), // count() can take predicates to filter
                          AverageDaysBorrowed = m.Average(m => ((m.ReturnDate ?? now) - m.LoanDate).TotalDays) // returnDate - LoanDate
                      }; // date subtraction works fine, but access .TotalDays to get days only

            q20.ToConsoleTable();
                      

        }
    }
}
