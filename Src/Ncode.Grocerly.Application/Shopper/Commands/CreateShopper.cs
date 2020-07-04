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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IIdGenerator _idGenerator;

        private readonly IClock _clock;

        public CreateShopper(IUnitOfWork unitOfWork, IIdGenerator idGenerator, IClock clock)
        {
            _unitOfWork = unitOfWork;
            _idGenerator = idGenerator;
            _clock = clock;
        }

        public void Handle(string username)
        {
            var isUserExists = _unitOfWork.Shoppers.Get(shopper => shopper.Username.Equals(username)).Any();
            if (isUserExists)
            {
                throw new DuplicateUsernameException();
            }

            var id = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var newShopper = new Shopper(id, username, createdDateTime);
            _unitOfWork.Shoppers.Add(newShopper);
            _unitOfWork.Save();
        }
    }
}
