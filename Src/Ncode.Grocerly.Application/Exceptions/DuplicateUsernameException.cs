using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Exceptions
{
    public class DuplicateUsernameException : Exception
    {
        public DuplicateUsernameException() : this("Username already exists.")
        {
        }

        public DuplicateUsernameException(string message)
            : base(message)
        {
        }

        public DuplicateUsernameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
