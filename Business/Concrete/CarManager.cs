using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        // Bu komut ile ister Memory de ister EntityFramework ile çalışabilirsin
        ICarDal _carDal;

        // bu constractor ile hangi veritabanı olursa olsun çalışır. Sadece istediğimiz veritabanını seçmemiz gerekiyor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                Console.WriteLine(Messages.carNameInvalid);
            }
            else if (car.DailyPrice < 0)
            {
                Console.WriteLine(Messages.carPriceInvalid);
            }
            else
            {
                // araç eklenebilir
                _carDal.Add(car);
                Console.WriteLine(Messages.carAdded);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(Messages.carDeleted);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(Messages.carUpdated);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
