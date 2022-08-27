using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2009, DailyPrice=300000, Description="Hatasız boyasız"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2012, DailyPrice=350000, Description="Hatasız boyasız, tramersiz"},
                new Car{Id=3, BrandId=2, ColorId=3, ModelYear=2004, DailyPrice=200000, Description="Ağır Hasar Kayıtlı"},
                new Car{Id=4, BrandId=2, ColorId=4, ModelYear=2015, DailyPrice=500000, Description="Memurdan Satılık"},
                new Car{Id=5, BrandId=3, ColorId=4, ModelYear=2022, DailyPrice=850000, Description="Sıfır ayarında"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == 1);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.BrandId == 2).ToList();
        }

        public void Update(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == 1);
            carToDelete.BrandId = 2;
            carToDelete.ColorId = 2;
            carToDelete.DailyPrice = 50000;
            carToDelete.Description = "Sakın ALMAAAA";
            carToDelete.ModelYear = 2020;
        }
    }
}
