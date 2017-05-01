using System.Collections.Generic;
using System.Linq;
using AcmeWebsite.App.IServices;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IServices;

namespace AcmeWebsite.AppApi.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : EntityBase
    {
        
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }


        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void AddList(IEnumerable<TEntity> obj)
        {
            _serviceBase.AddList(obj);
        }

        public void Delete(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        public void Delete(int id)
        {
            _serviceBase.Delete(id);
        }

        public void DeleteList(IEnumerable<TEntity> obj)
        {
            _serviceBase.DeleteList(obj);
        }

        public TEntity Get(int id)
        {
            return _serviceBase.Get(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _serviceBase.Get();
        }

        public TEntity First()
        {
            return _serviceBase.First();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            _serviceBase.AddOrUpdate(obj);
        }

        public void Commit()
        {
            _serviceBase.Commit();
        }

    }
}
