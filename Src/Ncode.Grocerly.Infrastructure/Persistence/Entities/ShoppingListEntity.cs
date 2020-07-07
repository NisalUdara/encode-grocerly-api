using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Infrastructure.Persistence.Entities
{
    internal class ShoppingListEntity : BaseEntity
    {
        public long OwnerId { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime FinishedDateTime { get; set; }

        public IList<ShoppingListItemEntity> Items { get; set; }
    }
}
