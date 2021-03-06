using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramewrok
{
    //generic constrete kısıtlamalar ekliyoruz
    public class EfEntityRepositoryBase<TEntity , TContext>:IEntityRepository<TEntity>
        where TEntity:class , IEntity,new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//reference yakala, veri kaynağı ile ilişkilendirme
                addedEntity.State = EntityState.Added; //nesneyi ekle
                context.SaveChanges(); //kaydet hepsini yap
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//reference yakala, veri kaynağı ile ilişkilendirme
                deletedEntity.State = EntityState.Deleted; //nesneyi sil
                context.SaveChanges(); //çalış kaydet
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//reference yakala, veri kaynağı ile ilişkilendirme
                updatedEntity.State = EntityState.Modified; //nesneyi güncelle
                context.SaveChanges(); //çalış kaydet
            }
        }

    }
}
