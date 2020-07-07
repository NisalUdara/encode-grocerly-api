using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Infrastructure.Persistence.Entities
{
    internal class BaseEntity
    {
        public long Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
