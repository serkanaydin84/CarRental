using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImageExists(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultCarImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage{CarId = carId,ImagePath = "DefaultImage.jpg", Date = DateTime.Now});
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
        
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            //Bir araba için eklenecek resim sayısına sınır koyuyoruz
            IResult result = BusinessRules.Run(CheckIfCarOfImageCountCorrect(carImage.CarId));

            //kurallarda herhangi bir hata varsa
            if (result != null)
            {
                //hatayı döndür
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagePath);
            carImage.Date=DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagePath + carImage.ImagePath,
                PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        //////////////////////////////////////////////////////////////////////////////////
        // *******************************************************************************
        //                          İŞ KURALLARI
        // *******************************************************************************
        //////////////////////////////////////////////////////////////////////////////////
        ///
        private IResult CheckIfCarOfImageCountCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.Id == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }

            return new SuccessResult();
        }

        private IResult CheckCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (result)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
