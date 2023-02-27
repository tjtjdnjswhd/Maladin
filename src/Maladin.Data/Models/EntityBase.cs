using Microsoft.EntityFrameworkCore;

namespace Maladin.Data.Models
{
    [PrimaryKey(nameof(Id))]
    public abstract class EntityBase
    {
        public int Id { get; set; }
    }
}