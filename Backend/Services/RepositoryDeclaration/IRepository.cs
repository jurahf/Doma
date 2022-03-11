using StoredModel;
using System;
using System.Collections.Generic;

namespace Services.RepositoryDeclaration
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll(int limit, int page);

        T GetById(int id);

        void Update(T entity);

        void Add(T entity);

        void Delete(int id);

        int GetCount();
    }
}
