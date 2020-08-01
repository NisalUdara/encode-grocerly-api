using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Common;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShopper : ICommand<string>
    {
        private readonly IGrocerlyDbContext _dbContext;

        private readonly IIdGenerator _idGenerator;

        private readonly IClock _clock;

        public CreateShopper(IGrocerlyDbContext dbContext, IIdGenerator idGenerator, IClock clock)
        {
            _dbContext = dbContext;
            _idGenerator = idGenerator;
            _clock = clock;
        }

        public void Handle(string username)
        {
            var isUserExists = _dbContext.Shoppers.Where(shopper => shopper.Username.Equals(username)).Any();
            if (isUserExists)
            {
                throw new DuplicateUsernameException();
            }

            var id = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var newShopper = new Shopper(id, username, createdDateTime);
            _dbContext.Shoppers.Add(newShopper);
        }
    }
}
