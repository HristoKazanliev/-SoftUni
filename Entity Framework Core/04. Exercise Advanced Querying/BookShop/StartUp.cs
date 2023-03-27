namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int command = int.Parse(Console.ReadLine());

            //string result = GetBooksByAgeRestriction(db, command);
            //string result = GetGoldenBooks(db);
            //string result = GetBooksByPrice(db);
            //string result = GetBooksNotReleasedIn(db, command);
            //string result = GetBooksByCategory(db, command);
            //string result = GetBooksReleasedBefore(db, command);
            //string result = GetAuthorNamesEndingIn(db, command);
            //string result = GetBookTitlesContaining(db, command);
            //string result = GetBooksByAuthor(db, command);
            //int result = CountBooks(db, command);
            //string result = CountCopiesByAuthor(db);
            string result = GetTotalProfitByCategory(db);


            Console.WriteLine(result);
            
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] bookTitles = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenEditionBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenEditionBooks);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var titlesAndPricesOfBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                 .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in titlesAndPricesOfBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksByCategory);
        }

        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBefore = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new 
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();   
        }

        //Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a)
                .ToArray();

            return string.Join(Environment.NewLine, authorNames);
        }

        //Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, booksByAuthor);
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksTitles = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return booksTitles.Length;
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksCopiesByAuthor = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(b => b.TotalCopies);


            foreach (var book in booksCopiesByAuthor)
            {
                sb.AppendLine($"{book.FullName} - {book.TotalCopies}");
            }
            
            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToArray()
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name);

            foreach (var book in booksProfit)
            {
                sb.AppendLine($"{book.Name} ${book.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


