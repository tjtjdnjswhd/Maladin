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

        public string Isbn { get; init; }
        public int Stock { get; init; }
        public int Price { get; init; }
    }
}
