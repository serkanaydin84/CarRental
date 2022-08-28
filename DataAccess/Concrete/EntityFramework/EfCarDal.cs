using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            // Normalde C#'da çöp toplayıcısı belli zamanlarda gelir ve bellek temizlik yapar ancak;
            // using nesnesi ile yazdığımız kodlar using bitince anında çöp toplayıcısı gelir ve beni bellekten at der.
            // Çünkü Context nesnesi biraz belleği yoran pahalı bir nesnedir. Burada kullanılan using'e;
            // IDispossable pattern implementation of C# denir.
            using (ReCapContext context=new ReCapContext())
            {
                // referansı yakalıyoruz
                var addedEntity = context.Entry(entity);
                // yakalanan referans aslında eklenecek bir nesne onu belirtiyoruz
                addedEntity.State = EntityState.Added;
                // burada da nesneyi ekliyoruz
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                // yakalanan referans silinecek nesne olarak belirtiyoruz
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                // yakalanan referans update edilecek nesne olarak belirtiyoruz
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context=new ReCapContext())
            {
                // bu satır aslında filter'a göre Tek satırlık Product nesnesi döndürecek
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()                   // filter null ise burası çalışır 
                    : context.Set<Car>().Where(filter).ToList();    // filter var ise burası çalışır
            }
        }
    }
}
