using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeWebsite.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : EntityBase
    {
        //This class, diferent from Repositorie, receive reference from Repositorie Project (DB), and still independent because dependency inversion
        
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            //Dependency Injection (after use concret class)
            _repository = repository;

        }

        public int Id { get; set; }
        public DateTime DateCreation { get; set; }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void AddList(IEnumerable<TEntity> obj)
        {
            _repository.AddList(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteList(IEnumerable<TEntity> obj)
        {
            _repository.DeleteList(obj);
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        public TEntity First()
        {
            return _repository.First();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            _repository.AddOrUpdate(obj);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


    }
}
