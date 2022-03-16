using Microsoft.EntityFrameworkCore;
using Services.RepositoryDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class BaseRepository<T> : IRepository<T> 
        where T : class, IEntity
    {
        protected readonly BookingDatabaseContext dbContext;

        public BaseRepository(BookingDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected virtual IQueryable<T> Fetch(IQueryable<T> set)
        {
            return set;
        }

        protected virtual IQueryable<T> DefaultOrder(IQueryable<T> set)
        {
            return set.OrderBy(x => x.Id);
        }

        /// <summary>
        /// Вызывается перед добавлением и обновлением сущности, чтобы связанные сущности были из этого же контекста
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void ReLoadRelations(T entity)
        {
        }

        public virtual int GetCount()
        {
            return dbContext.Set<T>().Count();
        }

        public virtual List<T> GetAll(int limit = 100, int page = 0)
        {
            return Fetch(
                    DefaultOrder(dbContext.Set<T>())
                    .Skip(page * limit)
                    .Take(limit))
                .ToList();
        }

        public virtual T GetById(int id)
        {
            return Fetch(dbContext.Set<T>())
                .FirstOrDefault(x => x.Id == id);
        }

        public virtual void Add(T entity)
        {
            try
            {
                ReLoadRelations(entity);

                dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                ReLoadRelations(entity);

                if (entity.Id > 0 && dbContext.Set<T>().Any(x => x.Id == entity.Id))
                {
                    if (dbContext.Entry(entity).State == EntityState.Detached)
                        dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.Update(entity);
                }
                else
                {
                    dbContext.Add(entity);
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
