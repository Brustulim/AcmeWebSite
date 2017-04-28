using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace AcmeWebsite.Repositories
{

    public class RepositoryForTests<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {

        private readonly List<TEntity> _InMemoryList;
        public bool isCommited; // To know in tests if the commit is called (because we working in a list on memory)
                
        public RepositoryForTests(List<TEntity> list)
        {
            _InMemoryList = list;
        }

        public void Add(TEntity obj)
        {
            obj.DateCreation = DateTime.Now;
            _InMemoryList.Add(obj);
        }

        public void AddList(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }


        public void Delete(TEntity obj)
        {
            _InMemoryList.Remove(obj);
        }

        public void Delete(int id)
        {
            //Here i use the get method to find itens to delete
            _InMemoryList.Remove(Get(id));
        }

        public void DeleteList(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }


        public TEntity Get(int id)
        {
            return _InMemoryList.FirstOrDefault(d => d.Id == id);
        }

        public IQueryable<TEntity> Get()
        {
            return _InMemoryList.AsQueryable();
        }

        public TEntity First()
        {
            return _InMemoryList.FirstOrDefault();
        }


        public void Update(TEntity obj)
        {
            //if we are using more complex entities, we can implement DataChange, UserChange here
            //obj.DateChange = DateTime.Now;
            _InMemoryList[_InMemoryList.IndexOf(Get(obj.Id))] = obj;
        }

        public void AddOrUpdate(TEntity obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        public void Commit()
        {
            isCommited = true;
        }

        public void Dispose()
        {
            //Not Implemented
        }
    }

}
