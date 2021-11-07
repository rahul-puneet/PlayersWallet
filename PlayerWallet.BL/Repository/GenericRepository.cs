using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.DAL.DatabasesContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PlayerWallet.BL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        protected DbSet<TEntity> _dbset;

        public GenericRepository(PlayerDbContext context)
        {
            _dbContext = context;
            _dbset = context?.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Attach(entity);
            }
            _dbContext.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbset.ToList();
        }


        public virtual void Delete(object id)
        {
            TEntity entityDelete = _dbset.Find(id);
            _dbContext.Remove(entityDelete);
            _dbContext.SaveChanges();
        }


        public virtual TEntity GetByID(object Id)
        {
            return _dbset.Find(Id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
