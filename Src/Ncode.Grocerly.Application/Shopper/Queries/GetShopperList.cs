using Ncode.Grocerly.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShopperList : IQuery<string, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShopperList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<string> Handle(string username)
        {
            var usernames = _unitOfWork.Shoppers
                .Get(shopper => shopper.Username.Contains(username))
                .Select(shopper => shopper.Username);

            return usernames;
        }
    }
}
