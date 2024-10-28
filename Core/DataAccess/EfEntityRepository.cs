using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
          where TEntity : class, IEntity, new()
          where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext()) 
            {
              var deletededEntity=context.Entry(entity);
              deletededEntity.State=EntityState.Added;
              context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

                //if(filter == null)
                //{
                //    return context.Set<TEntity>().ToList(); 
                //}
                //else
                //{
                //    context.Set<TEntity>().Where(filter).ToList();
                //}
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatededEntity = context.Entry(entity);
                updatededEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
