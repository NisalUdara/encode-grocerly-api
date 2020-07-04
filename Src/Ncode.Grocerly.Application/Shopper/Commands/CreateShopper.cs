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

        public CreateShopper(IUnitOfWork unitOfWork, IIdGenerator idGenerator)
        {
            _unitOfWork = unitOfWork;
            _idGenerator = idGenerator;
        }

        public void Handle(string username)
        {
            var isUserExists = _unitOfWork.Shoppers.Get(shopper => shopper.Username.Equals(username)).Any();
            if (isUserExists)
            {
                throw new DuplicateUsernameException();
            }

            var id = _idGenerator.CreateId();
            var newShopper = new Shopper(id, username);
            _unitOfWork.Shoppers.Add(newShopper);
            _unitOfWork.Save();
        }
    }
}
