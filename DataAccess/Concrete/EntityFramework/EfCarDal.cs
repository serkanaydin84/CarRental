using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public void Add(Car entity)
        {
            // Normalde C#'da çöp toplayıcısı belli zamanlarda gelir ve bellek temizlik yapar ancak;
            // using nesnesi ile yazdığımız kodlar using bitince anında çöp toplayıcısı gelir ve beni bellekten at der.
            // Çünkü Context nesnesi biraz belleği yoran pahalı bir nesnedir. Burada kullanılan using'e;
            // IDispossable pattern implementation of C# denir.
            using (CarRentalContext context=new CarRentalContext())
            {
                
                var addedEntity = context.Entry(entity);    // referansı yakalıyoruz       
                addedEntity.State = EntityState.Added;  // yakalanan referans aslında eklenecek bir nesne onu belirtiyoruz
                context.SaveChanges();  // burada da nesneyi ekliyoruz
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                // yakalanan referans silinecek nesne olarak belirtiyoruz
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                // yakalanan referans update edilecek nesne olarak belirtiyoruz
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                // bu satır aslında filter'a göre Tek satırlık Product nesnesi döndürecek
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()                   // filter null ise burası çalışır 
                    : context.Set<Car>().Where(filter).ToList();    // filter var ise burası çalışır
            }
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
