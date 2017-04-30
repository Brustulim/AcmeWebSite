using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;

namespace AcmeWebsite.Repositories
{

    public class RepositoryBase_old<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : EntityBase
    {

               
        protected readonly EfDbContext Context;
                
        public RepositoryBase_old(EfDbContext context)
        {
            Context = context;
        }

        
        public RepositoryBase_old()
        {
            //Context = context;
            Context = new EfDbContext();
        }
        
        private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }



        public void Add(TEntity obj)
        {
            obj.CreationDate = DateTime.Now;
            Entity.Add(obj);
        }

        public void AddList(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }


        public void Delete(TEntity obj)
        {
            Entity.Remove(obj);
        }

        public void Delete(int id)
        {
            //Here i use the get method to find itens to delete
            Entity.Remove(Get(id));
        }

        public void DeleteList(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }


        public TEntity Get(int id)
        {
            return Entity.Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return Entity;
        }

        public TEntity First()
        {
            return Entity.FirstOrDefault();
        }


        public void Update(TEntity obj)
        {
            //if we are using more complex entities, we can implement DataChange, UserChange here
            //obj.DateChange = DateTime.Now;
            Context.Entry(obj).State = EntityState.Modified;
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
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //Example how to catch errors when commiting data
                //Here we can implement mail or message send, insert on database log, etc.

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("ERROR Commiting data - Entity type: \"{0}\" - entity state: \"{1}\" - validation errors:"
                        ,eve.Entry.Entity.GetType().Name
                        , eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(" - Property: \"{0}\" - Error: \"{1}\""
                            ,ve.PropertyName
                            ,ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

}
