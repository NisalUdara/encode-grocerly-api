using IdGenGenerator = IdGen.IdGenerator;
using Ncode.Grocerly.Common;
using IdGen;

namespace Ncode.Grocerly.Application.Common
{
    public class IdGenerator : IIdGenerator
    {
        private readonly IdGenGenerator _idGenerator;
        public IdGenerator()
        {
            _idGenerator = new IdGenGenerator(1);
        }
        public long CreateId()
        {
            return _idGenerator.CreateId();
        }
    }
}
