using System;
using System.Collections.Generic;
using System.Globalization;
using LibraryConsoleApp.models;
using LibraryConsoleApp.Service;

namespace LibraryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            do
            {
                Console.WriteLine("----Welcome to Virtual Library---");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Book");
                Console.WriteLine("3. BookLogs");
                Console.WriteLine("4. Member");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose (1, 2, 3, 4, and 5):");

                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    BorrowBook();
                }
                else if (userInput == "2")
                {
                    Book();
                }
                else if (userInput == "3")
                {
                    BookLogs();
                }
                else if (userInput == "4")
                {
                    Member();
                }
                else if (userInput == "5")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("unidentified!");
                    running = ExitProgram();
                }
            } while (running == true);

        }
        
        /**
            <summary> BorrowBook is action for exit program. </summary>
        */
        private static void BorrowBook()
        {
            RepositoryBookLog service = new RepositoryBookLog();
            bool retry = true;
            while (retry == true)
            {
                Console.WriteLine("----Virtual Library---");
                Console.WriteLine("------Borrow Book-----");

                Console.WriteLine("Book Id : ");
                string bookId = Console.ReadLine();
                if (int.TryParse(bookId, out int idBook))
                {
                    RepositoryBook servicesB = new RepositoryBook();
                    Book resultBook = servicesB.SelectById(idBook);
                    if (resultBook != null)
                    {
                        if (resultBook.Remains != 0)
                        {
                            Console.WriteLine("Member Id : ");
                            string memberId = Console.ReadLine();
                            if (int.TryParse(memberId, out int idMember))
                            {
                                RepositoryMember servicesM = new RepositoryMember();
                                Member resultMember = servicesM.SelectById(idMember);
                                if (resultMember != null)
                                {
                                    string format = "yyyy.MM.dd HH:mm:ss:ffff";
                                    Console.WriteLine("DateTime Start (Ex.2013.07.12 15:32:04:4687) : ");
                                    string start = Console.ReadLine();
                                    Console.WriteLine("DateTime End (Ex.2013.07.12 15:32:04:4687) : ");
                                    string end = Console.ReadLine();
                                    DateTime dateStart = DateTime.ParseExact(start, format,
                                        CultureInfo.InvariantCulture);
                                    DateTime dateEnd = DateTime.ParseExact(end, format,
                                        CultureInfo.InvariantCulture);
                                    Console.WriteLine("Status : ");
                                    string status = Console.ReadLine();
                                    var bookLog = new BookLog()
                                    {
                                        StartTime = dateStart,
                                        EndTime = dateEnd,
                                        BookId = idBook,
                                        MemberId = idMember,
                                        Status = status
                                    };
                                    service.Add(bookLog);
                                    Book books = new Book();
                                    books.Id = resultBook.Id;
                                    books.Title = resultBook.Title;
                                    books.Author = resultBook.Author;
                                    books.Position = resultBook.Position;
                                    books.Qty = resultBook.Qty;
                                    books.Remains = resultBook.Remains - 1;
                                    servicesB.Change(books);
                                    
                                    Console.Clear();
                                    Console.WriteLine("Record Saved!\n");
                                    retry = RetryInput();
                                    
                                    
                                }
                                else
                                {
                                    Console.WriteLine("NotFound!");
                                    retry = RetryInput();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input!");
                                retry = RetryInput();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Out of Book");
                            retry = RetryInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NotFound!");
                        retry = RetryInput();
                    }
                    
                }
                
            }
        }
        /**
            <summary> Book is action for access book data. </summary>
         */
        private static void Book()
        {
            RepositoryBook service = new RepositoryBook();
            bool retry = true;
            while (retry == true)
            {
                Console.WriteLine("-----------------------------Virtual Library----------------------------");
                Console.WriteLine("--------------------------------Book Data-------------------------------");
                Console.WriteLine("Id \t Title \t Author \t Position \t Qty \t Remains");
                Console.WriteLine("________________________________________________________________________");
                List<Book> books = service.SelectAll();
                foreach (Book book in books)
                {
                    if (book.Id != null)
                    {
                        Console.WriteLine(book.Id + "\t" + book.Title + "\t" + book.Author +  "\t" + book.Position + "\t" + book.Qty + "\t" + book.Remains);
                        Console.WriteLine("_____________________________________________________________________");
                    }
                }
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("Choose (1, 2, and 3):");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.WriteLine("Title :");
                    string title = Console.ReadLine();
                    Console.WriteLine("Author :");
                    string auth = Console.ReadLine();
                    Console.WriteLine("Position :");
                    string position = Console.ReadLine();
                    Console.WriteLine("Quantity :");
                    string quantity = Console.ReadLine();
                    if (int.TryParse(quantity, out int qty))
                    {
                        Console.WriteLine("Remains :");
                        string remains = Console.ReadLine();
                        if (int.TryParse(remains, out int remain))
                        {
                            var book = new Book()
                            {
                                Title = title,
                                Author = auth,
                                Position = position,
                                Qty = qty,
                                Remains = remain
                            };
                            service.Add(book);
                            Console.Clear();
                            Console.WriteLine("Record Saved!\n");
                            retry = RetryInput();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input!");
                            retry = RetryInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        Console.WriteLine("Title :");
                        string title = Console.ReadLine();
                        Console.WriteLine("Author :");
                        string auth = Console.ReadLine();
                        Console.WriteLine("Position :");
                        string position = Console.ReadLine();
                        Console.WriteLine("Quantity :");
                        string quantity = Console.ReadLine();
                        if (int.TryParse(quantity, out int qty))
                        {
                            Console.WriteLine("Remains :");
                            string remains = Console.ReadLine();
                            if (int.TryParse(remains, out int remain))
                            {
                                Book _books = new Book();
                                _books.Id = _id;
                                _books.Title = title;
                                _books.Author = auth;
                                _books.Position = position;
                                _books.Qty = qty;
                                _books.Remains = remain;
                                service.Change(_books);
                                retry = RetryInput();
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input!");
                                retry = RetryInput();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input!");
                            retry = RetryInput();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        service.Delete(_id);
                        Console.WriteLine("Delete Success!");
                        retry = RetryInput();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else
                {
                    Console.WriteLine("unidentified!");
                    retry = RetryInput();
                }
                
            }

        }
        
        /**
            <summary> BookLogs is action for access BookLog data. </summary>
        */
        private static void BookLogs()
        {
            RepositoryBookLog service = new RepositoryBookLog();
            bool retry = true;
            while (retry == true)
            {
                Console.WriteLine("-----------------------------------Virtual Library---------------------------------");
                Console.WriteLine("------------------------------------BookLog Data-----------------------------------");
                Console.WriteLine("Id \t Start Time \t End Time \t BookId \t MemberId \t status");
                Console.WriteLine("___________________________________________________________________________________");
                List<BookLog> bookLogs = service.SelectAll();
                foreach (BookLog bookLog in bookLogs)
                {
                    if (bookLog.Id != null)
                    {
                        Console.WriteLine(bookLog.Id + "\t" + bookLog.StartTime + "\t" + bookLog.EndTime +  "\t" + bookLog.BookId + "\t" + bookLog.MemberId + "\t" + bookLog.Status);
                        Console.WriteLine("__________________________________________________________________________________");
                    }
                }
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("Choose (1, 2, and 3):");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    string format = "yyyy.MM.dd HH:mm:ss:ffff";
                    Console.WriteLine("DateTime Start (Ex.2013.07.12 15:32:04:4687) : ");
                    string start = Console.ReadLine();
                    Console.WriteLine("DateTime End (Ex.2013.07.12 15:32:04:4687) : ");
                    string end = Console.ReadLine();
                    // string eventdatetime = "2013.07.12 15:32:04:4687";
                    DateTime dateStart = DateTime.ParseExact(start, format,
                        CultureInfo.InvariantCulture);
                    DateTime dateEnd = DateTime.ParseExact(end, format,
                        CultureInfo.InvariantCulture);
                    Console.WriteLine("Book Id :");
                    string bookId = Console.ReadLine();
                    if (int.TryParse(bookId, out int idBook))
                    {
                        Console.WriteLine("Member Id :");
                        string memberId = Console.ReadLine();
                        if (int.TryParse(memberId, out int idMember))
                        {
                            Console.WriteLine("Status : ");
                            string status = Console.ReadLine();
                            var booklog = new BookLog()
                            {
                                StartTime = dateStart,
                                EndTime = dateEnd,
                                BookId = idBook,
                                MemberId = idMember,
                                Status = status,
                            };
                            service.Add(booklog);
                            Console.Clear();
                            Console.WriteLine("Record Saved!\n");
                            retry = RetryInput();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input!");
                            retry = RetryInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        string format = "yyyy.MM.dd HH:mm:ss:ffff";
                        Console.WriteLine("DateTime Start (Ex.2013.07.12 15:32:04:4687) : ");
                        string start = Console.ReadLine();
                        Console.WriteLine("DateTime End (Ex.2013.07.12 15:32:04:4687) : ");
                        string end = Console.ReadLine();
                        // string eventdatetime = "2013.07.12 15:32:04:4687";
                        DateTime dateStart = DateTime.ParseExact(start, format,
                            CultureInfo.InvariantCulture);
                        DateTime dateEnd = DateTime.ParseExact(end, format,
                            CultureInfo.InvariantCulture);
                        Console.WriteLine("Book Id :");
                        string bookId = Console.ReadLine();
                        if (int.TryParse(bookId, out int idBook))
                        {
                            Console.WriteLine("Member Id :");
                            string memberId = Console.ReadLine();
                            Console.WriteLine("Status : ");
                            string status = Console.ReadLine();
                            if (int.TryParse(memberId, out int IdMember))
                            {
                                BookLog bookLog = new BookLog();
                                bookLog.Id = _id;
                                bookLog.StartTime = dateStart;
                                bookLog.EndTime = dateEnd;
                                bookLog.BookId = idBook;
                                bookLog.MemberId = IdMember;
                                bookLog.Status = status;
                                service.Change(bookLog);
                                retry = RetryInput();
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input!");
                                retry = RetryInput();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input!");
                            retry = RetryInput();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        service.Delete(_id);
                        Console.WriteLine("Delete Success!");
                        retry = RetryInput();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else
                {
                    Console.WriteLine("unidentified!");
                    retry = RetryInput();
                }
                
            }

        }
        /**
            <summary> Member is action for access member data. </summary>
        */
        private static void Member()
        {
            RepositoryMember service = new RepositoryMember();
            bool retry = true;
            while (retry == true)
            {
                Console.WriteLine("-----------------------------Virtual Library----------------------------");
                Console.WriteLine("-------------------------------Member Data------------------------------");
                Console.WriteLine("Id \t Name \t Gender \t Phone \t Occupation \t Email");
                Console.WriteLine("________________________________________________________________________");
                List<Member> members = service.SelectAll();
                foreach (Member member in members)
                {
                    if (member.Id != null)
                    {
                        Console.WriteLine(member.Id + "\t" + member.Name + "\t" + member.Gender + "\t" + member.Phone + "\t" + member.Occupation + "\t" + member.Email);
                        Console.WriteLine("_____________________________________________________________________");
                    }
                }
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("Choose (1, 2, and 3):");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.WriteLine("Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Gender (M/F) : ");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Phone :");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Occupation :");
                    string job = Console.ReadLine();
                    Console.WriteLine("Email :");
                    string email = Console.ReadLine();
                    var _member = new Member() 
                    {
                        Name = name,
                        Gender = gender,
                        Phone = phone,
                        Occupation = job,
                        Email = email
                        
                    };
                    Console.WriteLine("belum masuk ");
                    service.Add(_member);
                    Console.WriteLine("masuk ");
                    Console.Clear();
                    Console.WriteLine("Record Saved!\n");
                    retry = RetryInput();
                    

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        Console.WriteLine("Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Gender (M/F) : ");
                        string gender = Console.ReadLine();
                        Console.WriteLine("Phone :");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Occupation :");
                        string job = Console.ReadLine();
                        Console.WriteLine("Email :");
                        string email = Console.ReadLine();
                        Member member = new Member(); 
                        member.Id = _id;
                        member.Name = name; 
                        member.Gender = gender;
                        member.Phone = phone;
                        member.Occupation = job;
                        member.Email = email;
                        service.Change(member);
                        retry = RetryInput();

                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Id :");
                    string id = Console.ReadLine();
                    if (int.TryParse(id, out int _id))
                    {
                        service.Delete(_id);
                        Console.WriteLine("Delete Success!");
                        retry = RetryInput();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!");
                        retry = RetryInput();
                    }
                }
                else
                {
                    Console.WriteLine("unidentified!");
                    retry = RetryInput();
                }
            }
        }
        
        /**
            <summary> RetryInput is action for retry program. </summary>
        */
        private static bool RetryInput()
        {
            Console.WriteLine("Do you want to retry?[y/n]");
            string inputUser = Console.ReadLine();
            bool retry = true;
            if (inputUser == "y" || inputUser == "Y")
            {
                retry = true;
            }
            else if (inputUser == "n" || inputUser == "N")
            {
                retry = false;
            }

            return retry;
        }
        /**
            <summary> ExitProgram is action for exit program. </summary>
            
        */
        private static bool ExitProgram()
        {
            Console.WriteLine("Do you want to exit?[y/n]:");
            string exit = Console.ReadLine();
            bool running = false;
            if (exit == "y" || exit == "Y")
            {
                running = false;
            }
            else if (exit == "n" || exit == "N")
            {
                running = true;
            }

            return running;
        }
        
    }

} 