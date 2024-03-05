using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Maladin.EFCore.Models.Abstractions
{
    [PrimaryKey(nameof(Id))]
    public abstract class EntityBase : IEntity
    {
        public int Id { get; private set; }

        [Timestamp]
        public byte[] Version { get; private set; }
    }
}