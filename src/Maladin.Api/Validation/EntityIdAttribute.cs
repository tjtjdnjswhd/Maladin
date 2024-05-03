using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Validation
{
    public class EntityIdAttribute : RangeAttribute
    {
        public EntityIdAttribute() : base(1, int.MaxValue)
        {
        }

        public override bool RequiresValidationContext => false;
    }
}