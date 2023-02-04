using Microsoft.EntityFrameworkCore;

namespace Maladin.Data.Models
{
    [PrimaryKey(nameof(Id))]
    public class EntityBase
    {
        public required int Id { get; set; }
    }
}
