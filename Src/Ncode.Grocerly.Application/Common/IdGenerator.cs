using Ncode.Grocerly.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Common
{
    public class IdGenerator : IIdGenerator
    {
        private readonly IdGenerator _idGenerator;
        public IdGenerator()
        {
            _idGenerator = new IdGenerator();
        }
        public long CreateId()
        {
            return _idGenerator.CreateId();
        }
    }
}
