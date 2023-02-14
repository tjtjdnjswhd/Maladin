namespace Maladin.Service.Models
{
    public sealed class BookContext
    {
        public BookContext(string isbn, int stock, int price)
        {
            Isbn = isbn;
            Stock = stock;
            Price = price;
        }

        public required string Isbn { get; init; }
        public required int Stock { get; init; }
        public required int Price { get; init; }
    }
}
