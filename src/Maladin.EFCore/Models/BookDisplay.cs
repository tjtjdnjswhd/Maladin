using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("BookDisplay")]
    public class BookDisplay : Goods
    {
        public BookDisplay(string name, string? overview, int price, string paperSize, int pageCount, string? coverUrl, DateTimeOffset publishedAt, int bookId, int authorId, int? translatorId, int publisherId, int categoryId) : base(name, overview, price, categoryId)
        {
            PaperSize = paperSize;
            PageCount = pageCount;
            CoverUrl = coverUrl;
            PublishedAt = publishedAt;
            BookId = bookId;
            AuthorId = authorId;
            TranslatorId = translatorId;
            PublisherId = publisherId;
        }

        public BookDisplay(string name, string? overview, int price, string paperSize, int pageCount, string? coverUrl, DateTimeOffset publishedAt, Book book, Author author, Translator? translator, Publisher publisher, GoodsCategory category) : base(name, overview, price, category)
        {
            PaperSize = paperSize;
            PageCount = pageCount;
            CoverUrl = coverUrl;
            PublishedAt = publishedAt;
            Book = book;
            Author = author;
            Translator = translator;
            Publisher = publisher;
        }

        [Required]
        public string PaperSize { get; set; }

        [Required]
        public int PageCount { get; set; }

        public string? CoverUrl { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset PublishedAt { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public int? TranslatorId { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public Book Book { get; set; }

        public Author Author { get; set; }

        public Translator? Translator { get; set; }

        public Publisher Publisher { get; set; }
    }
}