using System.Text;

namespace Members

{
    public abstract class Author(string firstname, string lastname)
    {
        public virtual string GetName()
        {
            return $"{Firstname} {Lastname}";
        }

        public string Firstname { get; set; } = firstname;
        public string Lastname { get; set; } = lastname;
    }

    public abstract class Book(
        string firstname, string lastname, string bookName, bool isForAdults)
            : Author(firstname, lastname)
    {
        public abstract override string GetName();

        public string BookName { get; set; } = bookName;
        public bool IsForAdults { get; set; } = isForAdults;
    }

    public class PublishingHouse(
        string firstname, string lastname, string bookName, bool isForAdults, string publishingHouseName)
            : Book(firstname, lastname, bookName, isForAdults)
    {
        public override string GetName()
        {
            // Perform a more complex operation
            var builder = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                builder.Append($"{PublishingHouseName} ");
            }
            return builder.ToString();
        }

        public string PublishingHouseName { get; set; } = publishingHouseName;
    }

    public sealed class SealedPublishingHouse(
        string firstname, string lastname, string bookName, bool isForAdults, string publishingHouseName)
            : Book(firstname, lastname, bookName, isForAdults)
    {
        public override string GetName()
        {
            // Perform a more complex operation
            var builder = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                builder.Append($"{PublishingHouseName} ");
            }
            return builder.ToString();
        }

        public string PublishingHouseName { get; set; } = publishingHouseName;
    }
}
