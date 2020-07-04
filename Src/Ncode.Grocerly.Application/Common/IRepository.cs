using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ncode.Grocerly.Application.Repository
{
    public interface IRepository<T> where T : Identity
    {
        void Add(T item);

        void Update(T item);

        void Delete(long id);

        T GetById(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
    }
}
