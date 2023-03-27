namespace Library
{
    internal class ProgramBase
    {

        public static Books createBook(string author,
                                       DateOnly yearofpublication,
                                       string genre,
                                       string language)
        {
            if (author is null)
            {
                throw new ArgumentNullException(nameof(author));
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
                string author = Console.ReadLine();
                Console.Write("ISBN: "); DateOnly yearofpublication = Console.ReadLine();
                Console.Write("Author: "); string genre = Console.ReadLine();
                Console.Write("Description: "); string language = Console.ReadLine();

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