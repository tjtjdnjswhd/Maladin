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

        public required string Title { get; init; }
        public required int Skip { get; init; }
        public required int Take { get; init; }
        public required DateTimeOffset? PublishDateStart { get; init; }
        public required DateTimeOffset? PublishDateEnd { get; init; }
        public required int? RatingStart { get; init; }
        public required int? RatingEnd { get; init; }
        public required int[]? CategoryIds { get; init; }
        public required int[]? PublisherIds { get; init; }
        public required int[]? AuthorIds { get; init; }
        public required int[]? TranslatorIds { get; init; }
    }
}