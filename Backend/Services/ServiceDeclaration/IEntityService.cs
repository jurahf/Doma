using System;
using System.Collections.Generic;
using ViewModel;

namespace Services.ServiceDeclaration
{
    public interface IEntityService<T> where T : IViewModel
    {
        int Add(T entity);

        T Get(int id);

        List<T> Get(int limit, int page);

        void Update(T entity);

        void Delete(int id);

        int GetCount();
    }
}
