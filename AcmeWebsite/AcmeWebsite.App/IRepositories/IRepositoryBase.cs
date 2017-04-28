using AcmeWebsite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeWebsite.Domain.IRepositories
{
    //Interface for repository (only can used by classes tha implements EntityBase)
    public interface IRepositoryBase<TEntity> : IDisposable  where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void AddList(IEnumerable<TEntity> obj);

        void Delete(TEntity obj);
        void Delete(int id);
        void DeleteList(IEnumerable<TEntity> obj);

        TEntity Get(int id);
        IQueryable<TEntity> Get();
        TEntity First();

        void Update(TEntity obj);
        void AddOrUpdate(TEntity obj);

        void Commit();
    }


}
