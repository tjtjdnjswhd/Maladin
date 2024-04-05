using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models
{
    public class Page
    {
        [Range(1, int.MaxValue)]
        public int Number { get; set; } = 1;

        [Range(1, int.MaxValue)]
        public int Count { get; set; } = 1;
    }
}