namespace LibraryManagement;

public class Program
{
    public static int BooksBorrowingLimit { get; set; } = 3;

    public static List<Book> Books { get; set; } = new()
    {
        new(""),
        new(""),
        new(""),
        new(""),
        new(""),
    };

    public static void Main(string[] args)
    {
        while (true)
        {
            OperationsPrompt();
        }
    }

    public static void OperationsPrompt()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Please choose the type of operation you want to execute:");
        System.Console.WriteLine("1. Add a new book.");
        System.Console.WriteLine("2. Remove a book from library.");
        System.Console.WriteLine("3. View all books.");
        System.Console.WriteLine("4. Search a book.");
        System.Console.WriteLine("5. Borrow a book.");
        System.Console.WriteLine("6. Return a book.");

        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddNewBook();
                break;
            case "2":
                RemoveBook();
                break;
            case "3":
                ViewAllBooks();
                break;
            case "4":
                SearchBook();
                break;
            case "5":
                BorrowBook();
                break;
            case "6":
                ReturnBook();
                break;

            default:
                PrintErrorMessage($"Type of operation with number {choice} does not exist.");
                break;
        }
    }

    public static void ReturnBook()
    {
        System.Console.WriteLine($"Please enter your username:");
        var username = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(username))
        {
            PrintErrorMessage("Empty strings are not allowed");
            return;
        }
        else
        {
            System.Console.WriteLine("Please enter the book title you want to return:");
            var bookTitle = Console.ReadLine();
            var selectedBook = Books.Where(x => x.Title == bookTitle).FirstOrDefault();
            if (selectedBook == default)
            {
                PrintErrorMessage("Book is not found");
            }
            else
            {
                selectedBook.CheckIn();
                PrintSuccessMessage();
            }
        }
    }

    public static void BorrowBook()
    {
        System.Console.WriteLine($"Please enter your username:");
        var username = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(username))
        {
            PrintErrorMessage("Empty strings are not allowed");
        }
        else
        {
            System.Console.WriteLine("Please enter the book title you want to borrow:");
            var bookTitle = Console.ReadLine();
            var selectedBook = Books.Where(x => x.Title == bookTitle).FirstOrDefault();
            if (selectedBook == default)
            {
                PrintErrorMessage("Book is not found");
            }
            else
            {
                if (Books.Where(x => x.CheckedOut && x.BorrowerUsername == username).Count() >= BooksBorrowingLimit)
                {
                    PrintErrorMessage("Sorry, but you cannot borrow any more books.");
                }
                else
                {

                    selectedBook.CheckOut(username);
                    PrintSuccessMessage();
                }
            }
        }
    }

    public static void SearchBook()
    {
        if (!Books.Any(x => !string.IsNullOrWhiteSpace(x.Title)))
        {
            PrintErrorMessage("The library is empty. No books to search for.");
        }
        else
        {
            System.Console.WriteLine("Please enter the title of a book you are looking for:");
            var searchInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                PrintErrorMessage("Empty or white space book titles are not allowed");
            }
            else
            {
                var searchedBook = Books.Where(x => x.Title == searchInput).FirstOrDefault();
                if (searchedBook == default)
                {
                    PrintErrorMessage("The book is not found");
                }
                else
                {
                    PrintSuccessMessage("The book is available");
                }
            }

        }
    }

    public static void ViewAllBooks()
    {
        if (Books.Any(x => !string.IsNullOrWhiteSpace(x.Title)))
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Book title    |   CheckedOut   |  BorrowerUsername");

            for (var i = 0; i < Books.Where(x => !string.IsNullOrWhiteSpace(x.Title)).Count(); i++)
            {
                var book = Books[i];
                System.Console.WriteLine($"{i + 1}. {book.Title},   {book.CheckedOut},  {book.BorrowerUsername ?? "None"}");
            }
        }
        else
        {
            PrintErrorMessage("The library is empty. No books to display.");
        }
    }

    public static void RemoveBook()
    {
        if (Books.Any(x => !string.IsNullOrWhiteSpace(x.Title)))
        {
            System.Console.WriteLine();
            Console.WriteLine("Enter the title of the book to remove:");
            string removeBookTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(removeBookTitle))
            {
                PrintErrorMessage("Empty or white space book titles are not allowed");
            }
            else
            {
                var removeBook = Books.Where(x => x.Title == removeBookTitle).FirstOrDefault();
                if (removeBook != default)
                {
                    Books.Remove(removeBook);
                    PrintSuccessMessage();
                }
                else
                {
                    PrintErrorMessage("The book is not found");
                }
            }
        }
        else
        {
            PrintErrorMessage("The library is empty. No books to remove.");
        }
    }

    public static void AddNewBook()
    {
        var emptySpot = Books.Where(x => string.IsNullOrWhiteSpace(x.Title)).FirstOrDefault();
        if (emptySpot == default)
        {
            PrintErrorMessage("The library is full. No more books can be added.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to add:");
            string newBookTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newBookTitle))
            {
                PrintErrorMessage("Empty or white space book titles are not allowed");
            }
            else
            {
                emptySpot.SetTitle(newBookTitle);
                PrintSuccessMessage();
            }
        }
    }

    public static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PrintSuccessMessage(string msg = "Operation successfully completed.")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.White;
    }
}



public class Book
{
    public Book(string title)
    {
        Title = title;
    }

    public void SetTitle(string title)
    {
        Title = title;
    }

    public void CheckIn()
    {
        BorrowerUsername = null;
        CheckedOut = false;
    }

    public void CheckOut(string borrowerUsername)
    {
        BorrowerUsername = borrowerUsername;
        CheckedOut = true;
    }

    public string Title { get; set; }

    public string? BorrowerUsername { get; set; } = null;
    public bool CheckedOut { get; set; } = false;
}