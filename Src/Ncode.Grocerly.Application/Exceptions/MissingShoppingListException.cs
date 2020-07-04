using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Exceptions
{
    public class MissingShoppingListException : Exception
    {
        public MissingShoppingListException() : this("Shopping list specified does not exist.")
        {
        }

        public MissingShoppingListException(string message)
            : base(message)
        {
        }

        public MissingShoppingListException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
