using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new() 
    {
        public void Add(TEntity entity)
        {
            // Normalde C#'da çöp toplayıcısı (garbage collection) belli zamanlarda gelir ve bellek temizlik yapar ancak;
            // using nesnesi ile yazdığımız kodlar using bitince anında çöp toplayıcısı gelir ve beni bellekten at der.
            // Çünkü Context nesnesi biraz belleği yoran pahalı bir nesnedir. Burada kullanılan using'e;
            // IDispossable pattern implementation of C# denir.
            using (TContext context=new TContext())
            {
                // referansı yakalıyoruz
                var addedEntity = context.Entry(entity);

                // yakalanan referansı aslında eklenecek bir nesne, onu belirliyoruz
                addedEntity.State = EntityState.Added;

                // nesneyi ekliyoruz
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                // filter a göre tek satırlık TEntity nesnesi döndürüyoruz
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                // filter null ise ilk kısım çalışır, yoksa ikinci kısım çalışır
                return filter == null
                    ? context.Set<TEntity>().ToList()                   // filter null ise
                    : context.Set<TEntity>().Where(filter).ToList();    // filter null değil ise
            }
        }
    }
}
