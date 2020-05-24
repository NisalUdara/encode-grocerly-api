using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain.Common
{
    public class Name
    {
        public string Text { get; private set; }

        public static Name For(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name has to  be non empty.");
            }
            var listItemName = new Name();
            listItemName.Text = name;
            return listItemName;
        }

        public static implicit operator string(Name name)
        {
            return name.ToString();
        }

        public static explicit operator Name(string name)
        {
            return For(name);
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            var isEqual = obj is Name name &&
                          Text.ToLower().Equals(name.Text.ToLower());

            return isEqual;
        }
    }
}
