using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Infrastructure.Persistence.Entities
{
    internal class ShoppingListItemEntity : BaseEntity
    {
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public int Quantity { get; set; }

        public bool IsPicked { get; set; }
    }
}
