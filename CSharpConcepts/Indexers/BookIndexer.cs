namespace Indexers
{
    public class Book(string author, string title)
    {
        public string Author { get; set; } = author;
        public string Title { get; set; } = title;
    }

    public class BookIndexer<T>
        where T : Book
    {
        private T[] _books = new T[100];

        public T this[int i]
        {
            get => _books[i];
            set
            {
                if (_books.Any(book => book != null && book.Title.Equals(value.Title, StringComparison.CurrentCultureIgnoreCase)

                    && book.Author.Equals(value.Author, StringComparison.CurrentCultureIgnoreCase)))
                {
                    throw new InvalidOperationException("Book already exists!");
                }
                else
                {
                    _books[i] = value;
                }
            }
        }
    }
}
