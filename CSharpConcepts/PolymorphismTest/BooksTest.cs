using Polymorphism;

namespace PolymorphismTest
{
    public class BooksTest
    {
        [Fact]
        public void GivenBooksWhenDerivedFromAuthorThenMembersAreReplaced()
        {
            //Arrange
            string bookName = "Book name";
            string bookFirstPage = "Book first page";
            
            string authorName = "Author name";
            string authorBioFirstPage = "Author bio first page";
            string authorBioSecondPage = "Author bio second page";

            //Act
            var book = new Books(bookName, authorName);
            book[0] = bookFirstPage;
            book.SetAuthorBio(authorBioFirstPage, 0);
            book.SetAuthorBio(authorBioSecondPage, 1);

            //Assert
            Assert.Equal(book.Name, bookName);
            Assert.Equal(book[0], bookFirstPage);
            Assert.Equal(100, book.CountPages());
            Assert.Equal("Override was cancelled.", book.GetPageAt(0));
            Assert.Equal(authorName, book.GetAuthorName());
            Assert.Equal(authorBioSecondPage, book.GetAuthorPage(1));
            Assert.Equal(1_000, book.CountAuthorBioPages());
        }
    }
}