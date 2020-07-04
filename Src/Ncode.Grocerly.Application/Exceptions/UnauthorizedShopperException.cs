using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Exceptions
{
    public class UnauthorizedShopperException : Exception
    {
        public UnauthorizedShopperException() : this("User is not authorized.")
        {
        }

        public UnauthorizedShopperException(string message)
            : base(message)
        {
        }

        public UnauthorizedShopperException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
