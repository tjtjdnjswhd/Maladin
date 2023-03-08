namespace Maladin.Service.Models
{
    public sealed class BookAddContext
    {
        public BookAddContext(string isbn, int stock, int price)
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