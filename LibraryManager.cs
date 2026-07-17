
/*
Title:          Final Project for Introduction to Programming with C#  by Microsoft
Date:           14.07.2026
Author:         Nico-Julian M.
*/

using System;
using System.Data;

namespace librarymanager
{
    class LibraryManager
    {
        public static void Main(string[] args)
        {
            // Important variables to initialize books 
            string bookID = "";
            string bookName = "";
            string bookContent = "";
            string isBorrowd = "No";

            // Important variables to support data entry
            int maxBooks = 10;
            int freeIndex = -1;
            int borrowCount = 0;
            string? readResult;
            string menuSelection = "";

            // Creating the array and the predefined book
            string[,] ourBooks = new string[maxBooks, 4];
            for (int i = 0; i < maxBooks; i++)
            {
                switch (i)
                {
                    case 0:
                        bookID = "B1";
                        bookName = "Learn C# Book";
                        bookContent = "How to lern C#";
                        isBorrowd = "No";
                        break;
                    default:
                        bookID = "";
                        bookName = "";
                        bookContent = "";
                        isBorrowd = "No";
                        break;
                }
                ourBooks[i, 0] = bookID;
                ourBooks[i, 1] = bookName;
                ourBooks[i, 2] = bookContent;
                ourBooks[i, 3] = isBorrowd;
            }

            // Creating an Interactive Menu
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Welcome to the NJM-Libraly managment app:");
                Console.WriteLine(" 1. List book");
                Console.WriteLine(" 2. Add book");
                Console.WriteLine(" 3. Remove book");
                Console.WriteLine(" 4. Search book");
                Console.WriteLine(" 5. Borrow book");
                Console.WriteLine(" 6. Return book");
                Console.WriteLine("Type Exit to exit.");
                Console.WriteLine();
                Console.WriteLine("Enter your selection");

                // Input Validation
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                // Implementation of the functions
                switch (menuSelection)
                {
                    case "1":

                        // List book
                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1] != "")
                            {
                                Console.WriteLine($"ID: {ourBooks[i, 0]}");
                                Console.WriteLine($"Name: {ourBooks[i, 1]}");
                                Console.WriteLine($"Content: {ourBooks[i, 2]}");
                                Console.WriteLine($"Borrowed: {ourBooks[i, 3]}");
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "2":

                        //Add book;
                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1] == "")
                            {
                                freeIndex = i;
                                break;
                            }
                        }

                        if (freeIndex == -1)
                        {
                            Console.WriteLine($"We have reached our limit {maxBooks} books that we can manage.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;
                        }

                        //Add Name
                        do
                        {
                            Console.WriteLine("Enter a name for your book.");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                bookName = readResult.ToLower();
                            }
                            else
                            {
                                bookName = "empty";
                            }
                        } while (bookName == "");

                        //Add Content
                        do
                        {
                            Console.WriteLine("Enter content description for your new book.");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                bookContent = readResult.ToLower();
                            }
                            else
                            {
                                bookContent = "empty";
                            }
                        } while (bookContent == "");

                        //saved data
                        bookID = "B" + (freeIndex + 1);
                        ourBooks[freeIndex, 0] = bookID;
                        ourBooks[freeIndex, 1] = bookName;
                        ourBooks[freeIndex, 2] = bookContent;
                        ourBooks[freeIndex, 3] = "No";
                        freeIndex = -1;
                        bookName = "";
                        bookContent = "";
                        break;

                    case "3":

                        //Remove book
                        Console.WriteLine("Enter the title of the book to remove:");
                        readResult = Console.ReadLine();
                        string removeTitle = readResult?.ToLower() ?? "";
                        bool foundBook1 = false;
                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1].ToLower() == removeTitle)
                            {
                                ourBooks[i, 0] = "";
                                ourBooks[i, 1] = "";
                                ourBooks[i, 2] = "";
                                ourBooks[i, 3] = "No";
                                foundBook1 = true;
                                Console.WriteLine("Book was removed.");
                                break;
                            }
                        }
                        if (!foundBook1)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "4":

                        //Search book
                        Console.WriteLine("Enter the title to search:");
                        readResult = Console.ReadLine();
                        string searchTitle = readResult?.ToLower() ?? "";
                        bool foundBook2 = false;

                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1].ToLower() == searchTitle)
                            {
                                Console.WriteLine("Book found:");
                                Console.WriteLine($"ID: {ourBooks[i, 0]}");
                                Console.WriteLine($"Name: {ourBooks[i, 1]}");
                                Console.WriteLine($"Content: {ourBooks[i, 2]}");
                                Console.WriteLine($"Borrowed: {ourBooks[i, 3]}");
                                foundBook2 = true;
                                break;
                            }
                        }
                        if (!foundBook2)
                        {
                            Console.WriteLine("Book not found.");
                        }

                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "5":

                        //Borrow book
                        Console.WriteLine("Enter the title to borrow:");
                        readResult = Console.ReadLine();
                        string borrowTitle = readResult?.ToLower() ?? "";
                        bool foundBook3 = false;

                        if (borrowCount >= 3)
                        {
                            Console.WriteLine("You already borrowed 3 books. Return one first.");
                            break;
                        }

                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1].ToLower() == borrowTitle)
                            {
                                foundBook3 = true;
                                if (ourBooks[i, 3].ToLower() == "yes")
                                {
                                    Console.WriteLine("This book is already borrowed.");
                                }
                                else
                                {
                                    Console.WriteLine("Borrow this book? (y/n)");
                                    readResult = Console.ReadLine();
                                    string answer = readResult?.ToLower() ?? "";
                                    if (answer == "y")
                                    {
                                        ourBooks[i, 3] = "Yes";
                                        borrowCount++;
                                        Console.WriteLine("Book borrowed.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book not borrowed.");
                                    }
                                }
                                break;
                            }
                        }
                        if (!foundBook3)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else if (borrowCount >= 3)
                        {
                            Console.WriteLine("We have reached our limit on the number of borrowed books.");
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "6":

                        //Return book
                        Console.WriteLine("Enter the title to return:");
                        readResult = Console.ReadLine();
                        string returnTitle = readResult?.ToLower() ?? "";
                        bool foundBook4 = false;

                        for (int i = 0; i < maxBooks; i++)
                        {
                            if (ourBooks[i, 1].ToLower() == returnTitle)
                            {
                                foundBook4 = true;
                                if (ourBooks[i, 3].ToLower() == "yes")
                                {
                                    ourBooks[i, 3] = "No";
                                    if (borrowCount > 0)
                                    {
                                        borrowCount--;
                                    }
                                    Console.WriteLine("Book returned.");
                                }
                                else
                                {
                                    Console.WriteLine("This book is not currently borrowed.");
                                }
                                break;
                            }
                        }
                        if (!foundBook4)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;
                }
            } while (menuSelection != "exit");
            
        }
    }
}