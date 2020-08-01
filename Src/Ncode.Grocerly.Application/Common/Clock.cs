using Ncode.Grocerly.Common;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Ncode.Grocerly.Application.Common
{
    public class Clock : IClock
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
