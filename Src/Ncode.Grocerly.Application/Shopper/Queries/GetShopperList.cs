using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShopperList : IQuery<string, IEnumerable<string>>
    {
        private readonly IRepository<Shopper> _repository;

        public GetShopperList(IRepository<Shopper> repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> Handle(string username)
        {
            var usernames = _repository
                .Get(shopper => shopper.Username.Contains(username))
                .Select(shopper => shopper.Username);

            return usernames;
        }
    }
}
