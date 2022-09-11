using Core.DataAccess.EntitiyFramework;
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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalContext>, IBrandDal
    {
        // Normalde C#'da çöp toplayıcısı belli zamanlarda gelir ve bellek temizlik yapar ancak;
        // using nesnesi ile yazdığımız kodlar using bitince anında çöp toplayıcısı gelir ve beni bellekten at der.
        // Çünkü Context nesnesi biraz belleği yoran pahalı bir nesnedir. Burada kullanılan using'e;
        // IDispossable pattern implementation of C# denir.
        public void Add(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }
    }
}
