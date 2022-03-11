using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services
{
    public class BaseEntityService<VM, DB> : IEntityService<VM>
        where VM : IViewModel
        where DB : IEntity
    {
        private readonly IRepository<DB> repository;
        protected readonly IEntityViewModelConverter<VM, DB> converter;

        public BaseEntityService(
            IRepository<DB> repository,
            IEntityViewModelConverter<VM, DB> converter)
        {
            this.repository = repository;
            this.converter = converter;
        }

        public virtual int Add(VM viewModel)
        {
            DB dbEntity = converter.ConvertToStoredModel(viewModel);
            repository.Add(dbEntity);
            return dbEntity.Id;
        }

        public virtual void Delete(int id)
        {
            repository.Delete(id);
        }

        public virtual VM Get(int id)
        {
            DB dbEntity = repository.GetById(id);
            return converter.ConvertToViewModel(dbEntity);
        }

        public virtual List<VM> Get(int limit = 100, int page = 0)
        {
            List<DB> dbEntityList = repository.GetAll(limit, page);
            return dbEntityList
                .Select(x => converter.ConvertToViewModel(x))
                .ToList();
        }

        public virtual int GetCount()
        {
            return repository.GetCount();
        }

        public virtual void Update(VM entity)
        {
            DB dbEntity = converter.ConvertToStoredModel(entity);
            //dbEntity.Id = entity.Id;
            repository.Update(dbEntity);
        }
    }
}
