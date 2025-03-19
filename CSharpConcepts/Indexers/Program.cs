using Indexers;

BookIndexer<Book> books = new BookIndexer<Book>();

books[0] = new Book("author", "name");

//Throw custom exception
books[1] = new Book("author", "name");


Console.ReadLine();