using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Burada T yi kısıtlamak istiyoruz
    // Bu sayede sadece bizim Db deki tablo class larımızı verileceğiz
    // Eğer böyle yapmazsak referans tiplerinin yanında değişken tiplerde implemente edilir
    // Bu bana " where T: generic constrait" generic kısıtlama denir
    // class : referans tip
    // IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    // new(): new'lenebilir olmalı. IEntity interface olduğu için ve interface ler new'lenemez
    //
    // YANİ "where T: class, IEntity, new()" bu ifade;
    // class olamalı,
    // IEntity olabilir veya IEntity den implemente bir nesne olabilir,
    // new'lenebilir olmalı yani interface olmamalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // bu ifade ile DB deki tüm veriler gertirilebileceği gibi
        // kullanıcının filtrelerine göre veya kısım kısım verileri getirebiliriz
        // burada filtre verilmeyebilir, o zaman tüm data getirilir yoksa filtreye göre data getirilir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        // tek bir data getirmek için veya herhangi bir datanın ayrıntısına gitğmek için kullanılır
        // burada ise filtre vermek zorunlu
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}