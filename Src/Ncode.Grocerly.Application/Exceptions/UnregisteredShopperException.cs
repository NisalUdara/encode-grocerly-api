using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Exceptions
{
    public class UnregisteredShopperException : Exception
    {
        public UnregisteredShopperException(): this("User is not registered.")
        {
        }

        public UnregisteredShopperException(string message)
            : base(message)
        {
        }

        public UnregisteredShopperException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
