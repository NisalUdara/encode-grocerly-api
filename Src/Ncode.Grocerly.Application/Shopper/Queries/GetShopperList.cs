using Ncode.Grocerly.Application.Common;
using System.Collections.Generic;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShopperList : IQuery<string, IEnumerable<string>>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetShopperList(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<string> Handle(string username)
        {
            var usernames = _dbContext
                .Shoppers
                .Where(shopper => shopper.Username.Contains(username))
                .Select(shopper => shopper.Username);

            return usernames;
        }
    }
}
