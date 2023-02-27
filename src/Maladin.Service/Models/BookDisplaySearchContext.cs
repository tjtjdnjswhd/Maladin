namespace Maladin.Service.Models
{
    public sealed class BookDisplaySearchContext
    {
        public BookDisplaySearchContext(string title, int skip, int take, DateTimeOffset? publishDateStart = null, DateTimeOffset? publishDateEnd = null, int? ratingStart = null, int? ratingEnd = null, int[]? categoryIds = null, int[]? publisherIds = null, int[]? authorIds = null, int[]? translatorIds = null)
        {
            Title = title;
            Skip = skip;
            Take = take;
            PublishDateStart = publishDateStart;
            PublishDateEnd = publishDateEnd;
            RatingStart = ratingStart;
            RatingEnd = ratingEnd;
            CategoryIds = categoryIds;
            PublisherIds = publisherIds;
            AuthorIds = authorIds;
            TranslatorIds = translatorIds;
        }

        public string Title { get; init; }
        public int Skip { get; init; }
        public int Take { get; init; }
        public DateTimeOffset? PublishDateStart { get; init; }
        public DateTimeOffset? PublishDateEnd { get; init; }
        public int? RatingStart { get; init; }
        public int? RatingEnd { get; init; }
        public int[]? CategoryIds { get; init; }
        public int[]? PublisherIds { get; init; }
        public int[]? AuthorIds { get; init; }
        public int[]? TranslatorIds { get; init; }
    }
}