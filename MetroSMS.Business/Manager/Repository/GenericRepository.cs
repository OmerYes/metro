using MetroSMS.Data.Model.ORM.Context;
using MetroSMS.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MetroSMS.Business.Manager.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        internal MetroSMSContext Context;
        internal DbSet<TEntity> DbSet;
        public GenericRepository(MetroSMSContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.AddDate = DateTime.Now;
                DbSet.Add(entity);
                Context.SaveChanges();
            }
            return entity;
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = DbSet.Find(entity.ID);
                Context.Entry(_entity).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            return DbSet.OrderByDescending(q => q.AddDate).ToList();
        }

        public IQueryable<TEntity> GetPhotoById(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q=>q.AddDate==DateTime.Today).Where(exp);
        }

        public IQueryable<TEntity> GetAllQuery()
        {
            return DbSet.Where(q => q.IsDeleted == false);
        }

        public IQueryable<TEntity> GetAllQuerableWithQuery(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.IsDeleted == false).Where(exp).OrderByDescending(q => q.AddDate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.IsDeleted == false).FirstOrDefault(exp);
        }
    }
}
