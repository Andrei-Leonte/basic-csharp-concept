namespace LinqQueriesConsole.PartialEntities
{
    public class EagerBook(
        int id,
        int authorId,
        int publishingHouseId,
        string title,
        bool isForAdults,
        string? authorName,
        string? publishingHouseName)
    {
        public int Id = id;

        public int AuthorId { get; set; } = authorId;
        public int PublishingHouseId { get; set; } = publishingHouseId;
        public string Title { get; set; } = title;
        public bool IsForAdults { get; set; } = isForAdults;
        public string? AuthorName { get; set; } = authorName;
        public string? PublishingHouseName { get; set; } = publishingHouseName;
    }
}
