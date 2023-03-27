using System.Text.Json;
namespace Library
{
    internal class Program
    {
        public class Books
        {
          
            public Books(string author, int yearofpublication, string genre, string language)
            {
                Author = author;
               YearOfPublication= yearofpublication;
                Genre = genre;
                Language = language;
            }

            public string Author { get; private set; }
            public int YearOfPublication { get; private set; }
            public string Genre { get; private set; }
            public string Language { get; private set; }

            public void show()
            {
                Console.WriteLine("Author of the book is " + Author );
                Console.WriteLine("The book was printed on " + YearOfPublication);
                Console.WriteLine("The book is  " + Genre + "genre");
                Console.WriteLine("The book is written in  " + Language +" language");

            }

            internal void Add(Books books)
            {
                throw new NotImplementedException();
            }

            internal Books Find(Func<object, bool> value)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {

            List<Books> books = new List<Books>();
            string fileName = "LibraryBooks.json";
            if (File.Exists(fileName))
            {
                books = readJsonFile(fileName);
            }

            bool stop = false;
            while (!stop)
            {
                Console.Write("Choose an option (0-3): ");
                Console.WriteLine("MENU");
                Console.WriteLine("[0] List of books ");
                Console.WriteLine("[1] Adding a book to the List");
                Console.WriteLine("[2] Remove book from the List");
                Console.WriteLine("[3] Exit ");
                try
                {
                    int choose = Convert.ToInt32(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            {
                                try
                                {
                                    foreach (Books book in books)
                                    {
                                        book.show();
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }

                        case 1:
                            {
                                try
                                {
                                    Books books = createList();
                                    books.Add(books);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                          

                        case 2:
                            try
                            {
                                Console.WriteLine("book to be remove?");
                                string author = Console.ReadLine();
                                try
                                {
                                    Books book = books.Find(b => b.Author.Contains(author));
                                    books.Where(b => b != book);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                            

                        case 3:
                            {
                                string outputJjsonString = JsonSerializer.Serialize(books);
                                File.Delete(fileName);
                                File.WriteAllText(fileName, outputJjsonString);
                                stop = true; break;
                            }
                            
                            

                        default: Console.WriteLine("Please enter the right number ,from 0 to 3."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error: {0}.\n\n Please input something", ex));
                }
            }
        }

        private static Books createList()
        {
            throw new NotImplementedException();
        }

        public static List<Books> readJsonFile(string json)
        {
            List<Books> books = new List<Books>();

            using (StreamReader r = new StreamReader(json))
            {
                string json_file = r.ReadToEnd();
                books = JsonSerializer.Deserialize<List<Books>>(json_file);
            }
            return books;
        }

        public static Books createBook(string author, int yearofpublication, string genre, string language)
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException($"'{nameof(author)}' cannot be null or empty.", nameof(author));
            }

            if (string.IsNullOrEmpty(genre))
            {
                throw new ArgumentException($"'{nameof(genre)}' cannot be null or empty.", nameof(genre));
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException($"'{nameof(language)}' cannot be null or empty.", nameof(language));
            }

            try
            {
                Console.Write("author: ");
                Console.Write("yearofpublication: ");
                Console.Write("Genre");
                Console.Write("Language: "); 

                string author = Console.ReadLine();
                int yearofpublication = Console.ReadLine();
                string genre = Console.ReadLine();
                string language = Console.ReadLine();
                return new Books(author, yearofpublication, genre, language);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
