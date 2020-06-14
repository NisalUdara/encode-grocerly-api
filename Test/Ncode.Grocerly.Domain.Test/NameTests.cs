using FluentAssertions;
using Ncode.Grocerly.Domain.Common;
using System;
using Xunit;

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
            string setName = name;
            setName.Should().Equals("Milk");
        }
    }
}
