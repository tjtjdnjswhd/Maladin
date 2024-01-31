using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Maladin.EFCore.ValueGenerators
{
    public class DateTimeOffsetUtcNowGenerator : ValueGenerator<DateTimeOffset>
    {
        public override DateTimeOffset Next(EntityEntry entry)
        {
            return DateTimeOffset.UtcNow;
        }

        public override bool GeneratesTemporaryValues => false;
    }
}