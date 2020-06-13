using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Domain.Test
{
    public class NameTests
    {
        [Fact]
        public void TestName()
        {
            Name name;
            Action assignEmpty = () => name = (Name)string.Empty;
            assignEmpty.Should().Throw<ArgumentException>().WithMessage("Product name has to  be non empty.");

            name = (Name)"Milk";
            name.Text.Should().Equals("Milk");
        }
    }
}
