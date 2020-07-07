using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Infrastructure.Persistence.Entities
{
    internal class ShareEntity : BaseEntity
    {
        public long ShopperId { get; set; }
        public long ShoppingListId { get; set; }
    }
}
