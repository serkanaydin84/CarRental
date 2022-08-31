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
            // CarDetailsTest();
            // CarAddTest();
            // CarUpdateTest();
            // CarDeleteTest();

            // BrandGetAllTest();
            // BrandAddTest();
            // BrandUpdateTest();
            // BrandDeleteTest();

            // ColorGetAllTest();
            // ColorAddTest();
            // ColorUpdateTest();
            // ColorDeleteTest();
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color
            {
                ColorId = 1003
            });
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color
            {
                ColorId = 1003,
                ColorName = "Sarı"
            });
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color
            {
                ColorName = "Lacivert"
            });
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand
            {
                BrandId = 2
            });
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand
            {
                BrandId = 1003,
                BrandName = "Mazda"
            });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandName = "Volvo"
            });
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            {
                Id = 2003
            });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                Id = 1,
                BrandId = 3,
                ColorId = 3,
                ModelYear = 2022,
                DailyPrice = 999999,
                Description = "YENİ GÜNCELLENDİ",
                CarName = "Fors Mustang"
            });
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
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
