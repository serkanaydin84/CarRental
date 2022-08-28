using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }

            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 2,
                ModelYear = 2019,
                Description = "Ağır Hasar Kayıtlı",
                DailyPrice = 255000
            });
        }
    }
}
