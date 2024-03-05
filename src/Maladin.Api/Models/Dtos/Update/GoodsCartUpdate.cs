using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class GoodsCartUpdate
    {
        [Range(1, int.MaxValue)]
        public required int Count { get; set; }
    }
}