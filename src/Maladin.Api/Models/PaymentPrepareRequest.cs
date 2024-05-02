using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models
{
    public class PaymentPrepareRequest
    {
        [Length(1, int.MaxValue)]
        public required Dictionary<int, int> OrderQtyByGoodsId { get; set; }

        [Range(0, int.MaxValue)]
        public int Point { get; set; }
    }
}