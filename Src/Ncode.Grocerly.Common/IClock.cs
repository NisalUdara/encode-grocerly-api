using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Common
{
    public interface IClock
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
